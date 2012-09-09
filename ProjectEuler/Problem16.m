% Problem 16 - Sum of digits of 2^1000
num = sym(2^1000);
array = sscanf(char(num), '%1d');
solution = sum(array);