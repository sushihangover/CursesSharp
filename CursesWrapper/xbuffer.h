#ifndef CURSES_SHARP_XBUFFER_H
#define CURSES_SHARP_XBUFFER_H

#ifdef HAVE_CONFIG_H
#include <config.h>
#endif

#include <assert.h>

#ifdef HAVE_STDLIB_H
#include <stdlib.h>
#endif

#ifdef HAVE_WCHAR_H
#include <wchar.h>
#endif


typedef unsigned short uchar2;

typedef struct xbuffer_s xbuffer;
struct xbuffer_s
{
	char* buf;
	char* bufend;
	char* bufcap;
	unsigned opts;
};

#define XBUF_EXPANDABLE	1
#define XBUF_OWN	2
#define XBUF_FILL	4


int xbuf_init(xbuffer* xb, char* prealloc, size_t maxlen, unsigned opts);

int xbuf_reserve(xbuffer* xb, size_t maxlen);

int xbuf_reserve_ext(xbuffer* xb, size_t capleft);

int xbuf_resize(xbuffer* xb, size_t len);

int xbuf_free(xbuffer* xb);

int xbuf_setopt(xbuffer* xb, unsigned opt);

int xbuf_resetopt(xbuffer* xb, unsigned opt);

int xbuf_isoptset(const xbuffer* xb, unsigned opt);


static inline
size_t xbuf_len(const xbuffer* xb)
{
	assert(xb != NULL);
	return (size_t)(xb->bufend - xb->buf);
}

static inline
size_t xbuf_maxlen(const xbuffer* xb)
{
	assert(xb != NULL);
	return (size_t)(xb->bufcap - xb->buf);
}

static inline
size_t xbuf_capleft(const xbuffer* xb)
{
	assert(xb != NULL);
	return (size_t)(xb->bufcap - xb->bufend);
}

static inline
const char* xbuf_data(const xbuffer* xb)
{
	assert(xb != NULL && xb->buf != NULL);
	return xb->buf;
}

static inline
char* xbuf_buf(xbuffer* xb, size_t maxlen)
{
	assert(xb != NULL);
	if (xbuf_reserve(xb, maxlen) < 0)
		return NULL;
	assert(xb->buf != NULL);
	return xb->buf;
}

static inline
int xbuf_ensure(xbuffer* xb, size_t capleft)
{
	assert(xb != NULL);
	if (xbuf_capleft(xb) < capleft)
		return xbuf_reserve_ext(xb, capleft);
	return 0;
}

static inline
void xbuf_put(xbuffer* xb, char c)
{
	assert(xb != NULL);
	assert(xbuf_capleft(xb) >= 1);
	*(xb->bufend) = c;
	xb->bufend++;
}

static inline
int xbuf_tzero(xbuffer* xb)
{
	assert(xb != NULL);
	if (xbuf_ensure(xb, 1) < 0)
		return -1;
	assert(xbuf_capleft(xb) >= 1);
	*(xb->bufend) = 0;
	return 0;
}

int xbuf_init_uc(xbuffer* xb, uchar2* prealloc, size_t maxlen, unsigned opts);

int xbuf_reserve_uc(xbuffer* xb, size_t maxlen);

int xbuf_resize_uc(xbuffer* xb, size_t len);

static inline
size_t xbuf_len_uc(const xbuffer* xb)
{
	assert(xb != NULL);
	return xbuf_len(xb) / sizeof(uchar2);
}

static inline
size_t xbuf_maxlen_uc(const xbuffer* xb)
{
	assert(xb != NULL);
	return xbuf_maxlen(xb) / sizeof(uchar2);
}

static inline
size_t xbuf_capleft_uc(const xbuffer* xb)
{
	assert(xb != NULL);
	return xbuf_capleft(xb) / sizeof(uchar2);
}

static inline
const uchar2* xbuf_data_uc(const xbuffer* xb)
{
	assert(xb != NULL && xb->buf != NULL);
	return (const uchar2*)xb->buf;
}

static inline
uchar2* xbuf_buf_uc(xbuffer* xb, size_t maxlen)
{
	assert(xb != NULL);
	if (xbuf_reserve_uc(xb, maxlen) < 0)
		return NULL;
	assert(xb->buf != NULL);
	return (uchar2*)xb->buf;
}

static inline
int xbuf_ensure_uc(xbuffer* xb, size_t capleft)
{
	return xbuf_ensure(xb, capleft * sizeof(uchar2));
}

static inline
void xbuf_put_uc(xbuffer* xb, uchar2 c)
{
	assert(xb != NULL);
	assert(xbuf_capleft_uc(xb) >= 1);
	*(uchar2*)(xb->bufend) = c;
	xb->bufend += sizeof(uchar2);
}

static inline
int xbuf_tzero_uc(xbuffer* xb)
{
	assert(xb != NULL);
	if (xbuf_ensure_uc(xb, 1) < 0)
		return -1;
	assert(xbuf_capleft_uc(xb) >= 1);
	*(uchar2*)(xb->bufend) = 0;
	return 0;
}

#ifdef HAVE_WCHAR_T
int xbuf_init_wc(xbuffer* xb, wchar_t* prealloc, size_t maxlen, unsigned opts);

int xbuf_reserve_wc(xbuffer* xb, size_t maxlen);

int xbuf_resize_wc(xbuffer* xb, size_t len);

static inline
size_t xbuf_len_wc(const xbuffer* xb)
{
	assert(xb != NULL);
	return xbuf_len(xb) / sizeof(wchar_t);
}

static inline
size_t xbuf_maxlen_wc(const xbuffer* xb)
{
	assert(xb != NULL);
	return xbuf_maxlen(xb) / sizeof(wchar_t);
}

static inline
size_t xbuf_capleft_wc(const xbuffer* xb)
{
	assert(xb != NULL);
	return xbuf_capleft(xb) / sizeof(wchar_t);
}

static inline
const wchar_t* xbuf_data_wc(const xbuffer* xb)
{
	assert(xb != NULL && xb->buf != NULL);
	return (const wchar_t*)xb->buf;
}

static inline
wchar_t* xbuf_buf_wc(xbuffer* xb, size_t maxlen)
{
	assert(xb != NULL);
	if (xbuf_reserve_wc(xb, maxlen) < 0)
		return NULL;
	assert(xb->buf != NULL);
	return (wchar_t*)xb->buf;
}

static inline
int xbuf_ensure_wc(xbuffer* xb, size_t capleft)
{
	return xbuf_ensure(xb, capleft * sizeof(wchar_t));
}

static inline
void xbuf_put_wc(xbuffer* xb, wchar_t c)
{
	assert(xb != NULL);
	assert(xbuf_capleft_wc(xb) >= 1);
	*(wchar_t*)(xb->bufend) = c;
	xb->bufend += sizeof(wchar_t);
}

static inline
int xbuf_tzero_wc(xbuffer* xb)
{
	assert(xb != NULL);
	if (xbuf_ensure_wc(xb, 1) < 0)
		return -1;
	assert(xbuf_capleft_wc(xb) >= 1);
	*(wchar_t*)(xb->bufend) = 0;
	return 0;
}
#endif

#endif /* CURSES_SHARP_XBUFFER_H */

