program laba4;
var
alphabet:  array ['А'..'Я'] of char;
str:string;
i,k:integer;
c,choose: char;
flag: boolean;
begin
  writeln ('Эта программа проверяет, является ли строка палиндромом ',chr(10), 'Введите слово или предложение.');
while true do
  begin  
  readln (str);
 
   
  for c:= 'А' to 'Я' do
    alphabet[c] := c; //заполняем массив алфавита
    
  for i := 1 to Length(str) do
    str[i] := UpCase(str[i]); //делаем все буквы заглавными
    
    k:= 1;
  writeln(str);  
  for i:= 1 to Length(str) do
    begin
      flag := true;
      for c:= 'А' to 'Я' do
        if str[k] = alphabet[c] then // сравниваем, является ли буква в слове буквой, а не символом
          begin
            flag := false; // если является, то ничего не происходит,все верно ,флаг - правда
            break;
          end;
      if flag = true then // если в слове нашелся символ
        begin
        Delete (str, k, 1); // удалеяем данный символ
        k:= k-1; // изменяем положение счетика, т.к. следующий символ сдвинулся назад      
        end;
      k:=k+1; // переходим к следующей букве
    end;  
  writeln(Length(str));  
  flag := true;  
    
  for i := 1 to Length(str) div 2 do
      if str[i] <> str[Length(str)-i+1] then
        begin
          flag := false;
          break;
        end;
    
      
  if flag = true then
    writeln ('Это палиндром')
  else
    writeln ('Это не палиндром'); 
    
   writeln ('Продолжить? Y/N');
   readln (choose);
  case choose of 
    'Y': continue;
    'N': exit;
  end;  
    
end;
end.