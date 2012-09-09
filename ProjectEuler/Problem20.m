% Problem 20 - Sum of digits of 100!
num = 1;

% The MATLAB factorial function - factorial(n) - becomes innaccurate for
% large values of n, so here we craft our own, using symbolic object
% accuracy
for i=1:100
    num=sym(num * i);
end

array = sscanf(char(num), '%1d');
solution = sum(array);