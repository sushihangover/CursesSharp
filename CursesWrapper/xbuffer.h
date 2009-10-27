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
	unsigned opts:8;
};

#define XBUF_EXPANDABLE	1
#define XBUF_OWN	2
#define XBUF_FILL	4


int xbuf_init(xbuffer* xb, char* prealloc, size_t maxlen, unsigned opts);

int xbuf_reserve(xbuffer* xb, size_t maxlen);

int xbuf_reserve_ext(xbuffer* xb, size_t len);

int xbuf_resize(xbuffer* xb, size_t len);

int xbuf_free(xbuffer* xb);

int xbuf_setopt(xbuffer* xb, unsigned opt);

int xbuf_resetopt(xbuffer* xb, unsigned opt);

int xbuf_isoptset(xbuffer* xb, unsigned opt);


static inline
size_t xbuf_len(xbuffer* xb)
{
	assert(xb != NULL);
	return (size_t)(xb->bufend - xb->buf);
}

static inline
size_t xbuf_maxlen(xbuffer* xb)
{
	assert(xb != NULL);
	return (size_t)(xb->bufcap - xb->buf);
}

static inline
char* xbuf_data(xbuffer* xb)
{
	assert(xb != NULL);
	return xb->buf;
}

static inline
int xbuf_append(xbuffer* xb, size_t len)
{
	size_t capleft;
	assert(xb != NULL);

	capleft = (size_t)(xb->bufcap - xb->bufend);
	if (len > capleft && xbuf_reserve_ext(xb, len) < 0)
		return -1;

	xb->bufend += len;
	return 0;
}


int xbuf_init_uc(xbuffer* xb, uchar2* prealloc, size_t maxlen, unsigned opts);

int xbuf_reserve_uc(xbuffer* xb, size_t maxlen);

int xbuf_resize_uc(xbuffer* xb, size_t len);

static inline
size_t xbuf_len_uc(xbuffer* xb)
{
	assert(xb != NULL);
	return xbuf_len(xb) / sizeof(uchar2);
}

static inline
size_t xbuf_maxlen_uc(xbuffer* xb)
{
	assert(xb != NULL);
	return xbuf_maxlen(xb) / sizeof(uchar2);
}

static inline
uchar2* xbuf_data_uc(xbuffer* xb)
{
	assert(xb != NULL);
	return (uchar2*)xb->buf;
}

#ifdef HAVE_WCHAR_T
int xbuf_init_wc(xbuffer* xb, wchar_t* prealloc, size_t maxlen, unsigned opts);

int xbuf_reserve_wc(xbuffer* xb, size_t maxlen);

int xbuf_resize_wc(xbuffer* xb, size_t len);

static inline
size_t xbuf_len_wc(xbuffer* xb)
{
	assert(xb != NULL);
	return xbuf_len(xb) / sizeof(wchar_t);
}

static inline
size_t xbuf_maxlen_wc(xbuffer* xb)
{
	assert(xb != NULL);
	return xbuf_maxlen(xb) / sizeof(wchar_t);
}

static inline
wchar_t* xbuf_data_wc(xbuffer* xb)
{
	assert(xb != NULL);
	return (wchar_t*)xb->buf;
}
#endif


typedef struct xreader_s xreader;
struct xreader_s
{
	const xbuffer* xbuf;
	const char* ptr;
};

int xrdr_init(xreader* xr, const xbuffer* xb);

static inline
size_t xrdr_left(xreader* xr)
{
	assert(xr != NULL);
	return (size_t)(xr->xbuf->bufend - xr->ptr);
}

static inline
char xrdr_get(xreader* xr)
{
	char r;
	assert(xr != NULL && xr->xbuf != NULL && xr->ptr != NULL);
	assert(xrdr_left(xr) > 0);
	r = *(xr->ptr);
	xr->ptr++;
	return r;
}

static inline
size_t xrdr_left_uc(xreader* xr)
{
	assert(xr != NULL && xr->xbuf != NULL);
	return xrdr_left(xr) / sizeof(uchar2);
}

static inline
uchar2 xrdr_get_uc(xreader* xr)
{
	uchar2 r;
	assert(xr != NULL && xr->xbuf != NULL && xr->ptr != NULL);
	assert(xrdr_left_uc(xr) > 0);
	r = *(const uchar2*)(xr->ptr);
	xr->ptr += sizeof(uchar2);
	return r;
}

#ifdef HAVE_WCHAR_T
static inline
size_t xrdr_left_wc(xreader* xr)
{
	assert(xr != NULL && xr->xbuf != NULL);
	return xrdr_left(xr) / sizeof(wchar_t);
}

static inline
wchar_t xrdr_get_wc(xreader* xr)
{
	wchar_t r;
	assert(xr != NULL && xr->xbuf != NULL && xr->ptr != NULL);
	assert(xrdr_left_wc(xr) > 0);
	r = *(const wchar_t*)(xr->ptr);
	xr->ptr += sizeof(wchar_t);
	return r;
}
#endif

typedef struct xwriter_s xwriter;
struct xwriter_s
{
	xbuffer* xbuf;
	char* ptr;
};

int xwrtr_init(xwriter* xr, xbuffer* xb);


static inline
size_t xwrtr_len(xwriter* xw)
{
	assert(xw != NULL && xw->xbuf != NULL);
	return (size_t)(xw->ptr - xw->xbuf->buf);
}

static inline
int xwrtr_append(xwriter* xw, size_t len)
{
	size_t of = xwrtr_len(xw);
	if (xbuf_append(xw->xbuf, len) < 0)
		return -1;
	xw->ptr = xw->xbuf->buf + of;
	return 0;
}

static inline
void xwrtr_put(xwriter* xw, char c)
{
	assert(xw != NULL && xw->xbuf != NULL && xw->ptr != NULL);
	assert(xbuf_maxlen(xw->xbuf) - xbuf_len(xw->xbuf) > 0);
	*(xw->ptr) = c;
	xw->ptr++;
}

static inline
int xwrtr_append_uc(xwriter* xw, size_t len)
{
	return xwrtr_append(xw, len * sizeof(uchar2));
}

static inline
size_t xwrtr_len_uc(xwriter* xw)
{
	assert(xw != NULL && xw->xbuf != NULL);
	return xwrtr_len(xw) / sizeof(uchar2);
}


static inline
void xwrtr_put_uc(xwriter* xw, uchar2 c)
{
	assert(xw != NULL && xw->xbuf != NULL && xw->ptr != NULL);
	assert(xbuf_maxlen_uc(xw->xbuf) - xbuf_len_uc(xw->xbuf) > 0);
	*(uchar2*)(xw->ptr) = c;
	xw->ptr += sizeof(uchar2);
}

#ifdef HAVE_WCHAR_T
static inline
int xwrtr_append_wc(xwriter* xw, size_t len)
{
	return xwrtr_append(xw, len * sizeof(wchar_t));
}

static inline
size_t xwrtr_len_wc(xwriter* xw)
{
	assert(xw != NULL && xw->xbuf != NULL);
	return xwrtr_len(xw) / sizeof(wchar_t);
}


static inline
void xwrtr_put_wc(xwriter* xw, wchar_t c)
{
	assert(xw != NULL && xw->xbuf != NULL && xw->ptr != NULL);
	assert(xbuf_maxlen_wc(xw->xbuf) - xbuf_len_wc(xw->xbuf) > 0);
	*(wchar_t*)(xw->ptr) = c;
	xw->ptr += sizeof(wchar_t);
}
#endif

#endif /* CURSES_SHARP_XBUFFER_H */

