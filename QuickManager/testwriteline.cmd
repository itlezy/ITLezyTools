@ECHO OFF

REM EXIT 1

set /a c=1
:BEGIN
ECHO Log Line bla bla
ECHO {glossary:{title:"example glossary",GlossDiv:{error:"AAA",title:"S",GlossList:{GlossEntry:{ID:"SGML",SortAs:"SGML",GlossTerm:"Standard %TIME% Generalized Markup Language",Acronym:"SGML",Abbrev:"ISO 8879:1986",GlossDef:{para:"A meta-markup language, used to create markup languages such as DocBook.",GlossSeeAlso:["GML","XML"]},GlossSee:"markup"}}}}}
ECHO "<xml1><ddd><eee><cccc></cccc></eee></ddd></xml1>"
ECHO E ERROR This is an error
ECHO %TIME% FATAL Wow
ECHO WARN Oops
ECHO ¿Ÿ£•
ECHO %C%

set /a c=c+1

if %C% EQU 1000 ( EXIT )

SLEEP -m 500
GOTO BEGIN
