/*
 * CursesSharp
 * 
 * Copyright 2009 Robert Konklewski
 * 
 * This library is free software; you can redistribute it and/or modify it
 * under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or (at your
 * option) any later version.
 *
 * This library is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Lesser General Public
 * License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * www.gnu.org/licenses/>.
 * 
 */

#include "xbuffer.h"
#include <string.h>
#include <errno.h>


static
int
xbuf_init_priv(xbuffer* xb, void* prealloc, size_t maxlen, unsigned opts)
{
	if (!xb) {
		errno = EINVAL;
		return -1;
	}

	xb->buf = prealloc;
	xb->bufend = xb->buf;
	xb->bufcap = xb->buf + maxlen;
	xb->opts = opts & 0xFF;

	if (xbuf_isoptset(xb, XBUF_FILL))
		xb->bufend += maxlen;

	return 0;
}

int
xbuf_init(xbuffer* xb, char* prealloc, size_t maxlen, unsigned opts)
{
	return xbuf_init_priv(xb, prealloc, maxlen, opts);
}

static int
fast_sqrt(int x)
{
	int res = 0;
	int one = 1 << 30;
	int resone;
	
	while (one > x)
		one >>= 2;

	while (one != 0) {
		resone = res + one;
		if (x >= resone) {
			x -= resone;
			res += one << 1;
		}
		res >>= 1;
		one >>= 2;
	}

	return res;
}

int
xbuf_reserve(xbuffer* xb, size_t maxlen)
{
	size_t capacity, newcapacity, length;
	char* newbuf;

	if (!xb) {
		errno = EINVAL;
		return -1;
	}

	capacity = xbuf_maxlen(xb);
	if (maxlen <= capacity)
		return 0;

	if (!xbuf_isoptset(xb, XBUF_EXPANDABLE)) {
		errno = ENOMEM;
		return -1;
	}

	newcapacity = capacity + fast_sqrt(capacity) + 1;
	if (newcapacity < maxlen)
		newcapacity = maxlen;
	assert(newcapacity > capacity);
	assert(newcapacity >= maxlen);

	length = xbuf_len(xb);
	assert(length <= newcapacity);

	newbuf = xbuf_isoptset(xb, XBUF_OWN) ? xb->buf : 0;
	newbuf = realloc(newbuf, newcapacity);
	if (!newbuf)
		return -1;
	if (!xbuf_isoptset(xb, XBUF_OWN))
		memcpy(newbuf, xb->buf, capacity);

	xb->buf = newbuf;
	xb->bufend = newbuf + length;
	xb->bufcap = newbuf + newcapacity;
	xbuf_setopt(xb, XBUF_OWN);

	return 0;
}

int
xbuf_reserve_ext(xbuffer* xb, size_t len)
{
	if (!xb) {
		errno = EINVAL;
		return -1;
	}

	return xbuf_reserve(xb, xbuf_len(xb) + len);
}

int
xbuf_resize(xbuffer* xb, size_t len)
{
	if (xbuf_reserve(xb, len) < 0)
		return -1;
	
	xb->bufend = xb->buf + len;

	return 0;
}

int
xbuf_free(xbuffer* xb)
{
	if (!xb) {
		errno = EINVAL;
		return -1;
	}

	if (xbuf_isoptset(xb, XBUF_OWN))
		free(xb->buf);

	xb->buf = 0;
	xb->bufend = 0;
	xb->bufcap = 0;

	return 0;
}

int
xbuf_setopt(xbuffer* xb, unsigned opt)
{
	if (!xb) {
		errno = EINVAL;
		return -1;
	}
	xb->opts |= opt & 0xFF;
	assert(xbuf_isoptset(xb, opt));
	return (int)(xb->opts);
}

int
xbuf_resetopt(xbuffer* xb, unsigned opt)
{
	if (!xb) {
		errno = EINVAL;
		return -1;
	}
	xb->opts &= ~opt & 0xFF;
	assert(!xbuf_isoptset(xb, opt));
	return (int)(xb->opts);
}

int 
xbuf_isoptset(const xbuffer* xb, unsigned opt)
{
	if (!xb) {
		errno = EINVAL;
		return -1;
	}
	return ((xb->opts & opt) ? 1 : 0);
}

int 
xbuf_init_uc(xbuffer* xb, uchar2* prealloc, size_t maxlen, unsigned opts)
{
	return xbuf_init_priv(xb, prealloc, maxlen * sizeof(uchar2), opts);
}

int 
xbuf_reserve_uc(xbuffer* xb, size_t maxlen)
{
	return xbuf_reserve(xb, maxlen * sizeof(uchar2));
}

int 
xbuf_resize_uc(xbuffer* xb, size_t len)
{
	return xbuf_resize(xb, len * sizeof(uchar2));
}

#ifdef HAVE_WCHAR_T
int 
xbuf_init_wc(xbuffer* xb, wchar_t* prealloc, size_t maxlen, unsigned opts)
{
	return xbuf_init_priv(xb, prealloc, maxlen * sizeof(wchar_t), opts);
}

int 
xbuf_reserve_wc(xbuffer* xb, size_t maxlen)
{
	return xbuf_reserve(xb, maxlen * sizeof(wchar_t));
}

int 
xbuf_resize_wc(xbuffer* xb, size_t len)
{
	return xbuf_resize(xb, len * sizeof(wchar_t));
}
#endif

