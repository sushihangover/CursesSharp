# CS_LANG_CALLS(PROLOGUE, FUNCTION)
# -----------------------------------
# Avoid conflicting decl of main.
m4_define([CS_LANG_CALLS],
[AC_LANG_PROGRAM([int cs_lang_calls_ret;
$1
/* Override any GCC internal prototype to avoid an error.
   Use char because int might match the return type of a GCC
   builtin and then its argument prototype would still apply.  */]
m4_foreach_w([cs_fname], [$2],
  [m4_if([cs_fname], [main], [],
    [#ifdef __cplusplus
extern "C"
#endif
char cs_fname ();
  ])]
),
m4_foreach_w([cs_fname], [$2],
  [cs_lang_calls_ret = ][cs_fname][ ();]
)[return (cs_lang_calls_ret);]
)
])

# CS_SEARCH_LIBS(FUNCTION, SEARCH-LIBS,
#                [ACTION-IF-FOUND], [ACTION-IF-NOT-FOUND],
#                [OTHER-LIBRARIES])
# --------------------------------------------------------
# Search for a library defining FUNC, if it's not already available.
AC_DEFUN([CS_SEARCH_LIBS],
[AS_VAR_PUSHDEF([cs_Search], [cs_cv_search_$1])
AC_CACHE_CHECK([for library containing $1], [cs_Search],
[cs_func_search_save_LIBS=$LIBS
AC_LANG_CONFTEST([CS_LANG_CALLS([], [$1])])
cs_other_LIBS=""
for cs_lib in $5; do
  cs_other_LIBS="-l$cs_lib $cs_other_LIBS"
done
for cs_lib in '' $2; do
  cs_extra=""
  if test -z "$cs_lib"; then
    cs_res="none required"
  else
    cs_res="-l$cs_lib"
    LIBS="-l$cs_lib $cs_func_search_save_LIBS"
  fi
  AC_LINK_IFELSE([],
    [AS_VAR_SET([cs_Search], [$cs_res])],
    [cs_extra="$cs_other_LIBS"
     LIBS="$cs_extra $cs_func_search_save_LIBS"
     test -z "$cs_lib" || LIBS="-l$cs_lib $LIBS"
     AC_LINK_IFELSE([], [AS_VAR_SET([cs_Search], [$cs_res])])
  ])
  AS_VAR_SET_IF([cs_Search], [break])
done
AS_VAR_SET_IF([cs_Search], , [AS_VAR_SET([cs_Search], [no])])
rm -f conftest.$ac_ext
LIBS=$cs_func_search_save_LIBS])
cs_res=AS_VAR_GET([cs_Search])
AS_IF([test "$cs_res" != no],
  [LIBS="$cs_extra $LIBS"
  test "$cs_res" = "none required" || LIBS="$cs_res $LIBS"
  $3],
  [$4])
AS_VAR_POPDEF([cs_Search])dnl
])

