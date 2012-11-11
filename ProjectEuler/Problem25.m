% Problem 25 - First term to have 1000 digits in Fibonacci sequence
numbers = [sym(1), sym(1)];
lock = false;
bound = 1000;

clc;

while ~lock
    numbers(length(numbers)+1) = sym(numbers(length(numbers)) + numbers(length(numbers)-1));
    
    if length(char(numbers(length(numbers)))) >= 1000
        break;
    end
end

fprintf('Solution: %s\n', length(numbers))