% Problem 13 - First 10 digits of sum of one hundred 50-digit numbers

fid = fopen('Problem13.txt');

solution = 0;

% Load values from textfile
for i=1:100
   C{i} = fgetl(fid);
end

% Summation
for i=1:100
   solution = sym(solution) + sym(C{i});
end

% Get first 10 digits
digits = sscanf(char(sym(solution)), '%1d');

solution = '';

for i=1:10
    solution = strcat(solution, num2str(digits(i)));
end

clc
fprintf('Solution: %s\n', solution);

fclose(fid);