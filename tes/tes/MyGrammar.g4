grammar MyGrammar;

// ŞÇÚÏÉ ÇáÈÑäÇãÌ ÇáÑÆíÓí
program: statement+ ;

// ÇáŞÇÚÏÉ ÇáÃÓÇÓíÉ ááÊÚáíãÇÊ
statement: listDeclaration 
         | printStatement 
		 | addStatement
		 | removeStatement
		 | containStatement
         ;

// ÊÚÑíİ ŞÇÆãÉ
listDeclaration: 'list<int>' ID '=' '{' NUMBER (',' NUMBER)* '}' ';' ;

// ØÈÇÚÉ ÚäÕÑ ãä ÇáŞÇÆãÉ
printStatement: 'print' '(' ID '[' NUMBER ']' ')' ';' ;

addStatement: ID '.add(' NUMBER ')' ';' ;
removeStatement : ID '.remove(' NUMBER ')' ';' ;
containStatement: ID '.contain(' NUMBER ')' ';' ;
// ÇáÊÚÑíİÇÊ ÇáÃÓÇÓíÉ
ID: [a-zA-Z_][a-zA-Z0-9_]* ;   // ÃÓãÇÁ ÇáãÊÛíÑÇÊ
NUMBER: [0-9]+ ;               // ÊÚÑíİ ÇáÃÑŞÇã
WS: [ \t\r\n]+ -> skip ;       // ÊÌÇåá ÇáãÓÇİÇÊ
