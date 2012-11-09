% Problem 12
lock = false;
max = 0;
threshold = 500;
i = 0;
num = 0;
divisors = [];

clc;

while ~lock
    divisors = [];
    i = i+1;
    num = (i^2+i)/2;
    max = ceil(sqrt(num));
    
    for x=1:max-1
        if mod(num, x) == 0
            divisors(length(divisors)+1) = x;
            if x ~= max
                divisors(length(divisors)+1) = num/x;
            end
        end
    end
    
    if length(divisors) > threshold
       lock = true; 
    end    
end

fprintf('Number is: %d', num);
