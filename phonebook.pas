program phonebook;

type
phoneDB = record
name : record
Fname : string[20];
Lname : string[20];
Mname : string[20];
end;
address : record
street : string [20];
Hnumber : integer;
Rnumber : integer;
end;
phone_number : record
number1: uint64;
number2: uint64;
end;
end;

procedure create (f: file of phoneDB) ;
var
  a: phoneDB;
  i : string;
begin
  
      writeln ('Введите информацию о человеке.Если поле отсутсвует  нажмите SpaceBar, а затем Enter ');
      writeln ('Введите фамилию');
      readln (a.name.Lname);
      writeln ('Введите имя');
      readln (a.name.Fname);
      writeln ('Введите отчество');
      readln (a.name.Mname);
      writeln ('Введите улицу');
      readln (a.address.street);
      writeln ('Введите номер дома');
      readln (i);
      if i <> ' ' then  
        a.address.Hnumber := strtoint(i);
      writeln ('Введите номер квартиры');
      readln (i);
      if i <> ' ' then  
        a.address.Rnumber := strtoint(i);
      writeln ('Введите основной номер телефона');
      readln (a.phone_number.number1);
      writeln ('Введите дополнительный номер телефона');
      readln (i);
      if i <> ' ' then  
        a.phone_number.number2 := strtoint(i);
      write(f,a);
end;

procedure view (f: file of phoneDB);
var
a: phoneDB;
begin
  Seek(f,0);
  while not eof(f) do
    begin
      read (f,a); 
      writeln('ФИО: ', a.name.Lname, ' ', a.name.Fname, ' ', a.name.Mname, #10,
              'Адрес: улица ', a.address.street, ', дом: ', a.address.Hnumber, ', квартира: ', a.address.Rnumber, #10,
              'Телефон: ', a.phone_number.number1, ', доп.телефон: ', a.phone_number.number2, #10);
    end;
end;  

procedure search_name (f: file of phoneDB);
var
key: string;
fl: boolean;
a: phoneDB;
begin
  writeln ('Введите имя или фамилию:');
  readln (key);
  fl := true;
  while not eof(f) do
    begin
      read (f,a);
      if (key = a.name.Lname) or (key = a.name.Fname) or (key = a.name.Mname) then
      begin
        fl := false;
        writeln('ФИО: ', a.name.Lname, ' ', a.name.Fname, ' ', a.name.Mname, #10,
                'Адрес: улица ', a.address.street, ', дом: ', a.address.Hnumber, ', квартира: ', a.address.Rnumber, #10,
                'Телефон: ', a.phone_number.number1, ', доп.телефон: ', a.phone_number.number2, #10);  
      end;

end;
  if fl = true then
        writeln ('Совпадений не найдено'); 
end;  

procedure search_PH (f: file of phoneDB);
var
key: uint64;
fl: boolean;
a: phoneDB;
begin
  writeln ('Введите номер телефона');
  readln (key);
  fl := true;
  while not eof(f) do
    begin
      read (f,a);
      if (key = a.phone_number.number1) or (key = a.phone_number.number2) then
      begin
        fl := false;
        writeln('ФИО: ', a.name.Lname, ' ', a.name.Fname, ' ', a.name.Mname, #10,
                'Адрес: улица ', a.address.street, ', дом: ', a.address.Hnumber, ', квартира: ', a.address.Rnumber, #10,
                'Телефон: ', a.phone_number.number1, ', доп.телефон: ', a.phone_number.number2, #10);  
      end;

end;
  if fl = true then
        writeln ('Совпадений не найдено'); 
end;        
        
procedure delete (f: file of phoneDB);
var
buf: phoneDB;
N,i,j : integer;
begin
  
  writeln ('Выберете запись для удаления');
  readln (j);
  N := FileSize(f);
  for j := 0 to N-1 do
  begin
    Seek(f,j);
    i := j + 1;
    
    
end;
        
end;  

var
  PhB : file of phoneDB;
  choose: integer;
  
begin
  
  assign (PhB, 'PhoneBook.dat');
  if fileexists ('PhoneBook.dat') then
    reset (PhB)
  else
    rewrite (PhB);  
 
  while true do
    begin
      Seek(PhB,FileSize(PhB));
      writeln ('Выберите опцию и введите ее номер', #10,
               '1. Добавить запись', #10,
               '2. Посмотреть все записи',#10,
               '3. Поиск по номеру телефона ',#10,
               '4. Поиск по имени', #10,
               '5. Удалить запись',#10,
               '6. Выход из программы');
      readln(choose);
      case choose of
      1: create(PhB);
      2: view(PhB);
      3: search_name(PhB);
      4: search_PH (PhB);
      5: delete(PhB);
      6: exit;
      end; 
    end;  
    close(PhB);  

end.