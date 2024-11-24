grammar MyGrammar;

// ����� �������� �������
program: statement+ ;

// ������� �������� ���������
statement: listDeclaration 
         | printStatement 
		 | addStatement
		 | removeStatement
		 | containStatement
         ;

// ����� �����
listDeclaration: 'list<int>' ID '=' '{' NUMBER (',' NUMBER)* '}' ';' ;

// ����� ���� �� �������
printStatement: 'print' '(' ID '[' NUMBER ']' ')' ';' ;

addStatement: ID '.add(' NUMBER ')' ';' ;
removeStatement : ID '.remove(' NUMBER ')' ';' ;
containStatement: ID '.contain(' NUMBER ')' ';' ;
// ��������� ��������
ID: [a-zA-Z_][a-zA-Z0-9_]* ;   // ����� ���������
NUMBER: [0-9]+ ;               // ����� �������
WS: [ \t\r\n]+ -> skip ;       // ����� ��������
