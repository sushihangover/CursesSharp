# CS_SEARCH_LIBS(FUNCTION, SEARCH-LIBS,
#                [ACTION-IF-FOUND], [ACTION-IF-NOT-FOUND],
#                [OTHER-LIBRARIES])
# --------------------------------------------------------
# Search for a library defining FUNC, if it's not already available.
AC_DEFUN([CS_SEARCH_LIBS],
[AS_VAR_PUSHDEF([cs_Search], [cs_cv_search_$1])dnl
AC_CACHE_CHECK([for library containing $1], [cs_Search],
[cs_func_search_save_LIBS=$LIBS
AC_LANG_CONFTEST([AC_LANG_CALL([], [$1])])
cs_other_LIBS=""
for cs_lib in $5; do
  cs_other_LIBS="-l$cs_lib $cs_other_LIBS"
done
for cs_lib in '' $2; do
  if test -z "$cs_lib"; then
    cs_res="none required"
    cs_all_LIBS="$cs_other_LIBS $cs_func_search_save_LIBS"
  else
    cs_res=-l$cs_lib
    LIBS="-l$cs_lib $cs_func_search_save_LIBS"
    cs_all_LIBS="-l$cs_lib $cs_other_LIBS $cs_func_search_save_LIBS"
  fi
  AC_LINK_IFELSE([],
    [AS_VAR_SET([cs_Search], [$cs_res])],
    [LIBS="$cs_all_LIBS"
     AC_LINK_IFELSE([], [AS_VAR_SET([cs_Search], [$cs_res])])]dnl
  )
  AS_VAR_SET_IF([cs_Search], [break])dnl
done
AS_VAR_SET_IF([cs_Search], , [AS_VAR_SET([cs_Search], [no])])dnl
rm -f conftest.$ac_ext
LIBS=$cs_func_search_save_LIBS])
cs_res=AS_VAR_GET([cs_Search])
AS_IF([test "$cs_res" != no],
  [test "$cs_res" = "none required" || LIBS="$cs_res $LIBS"
  $3],
      [$4])dnl
AS_VAR_POPDEF([cs_Search])dnl
])
