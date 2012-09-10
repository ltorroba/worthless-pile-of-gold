% Problem 14 - Collatz Problem

bound = 1000000;
results = zeros(bound,2);

for i=2:bound
    curr = i;
    loops = 0;
    
    while curr ~= 1;
        if(mod(curr,2)==0) % even
            curr = curr/2;
        else % odd
            curr = 3*curr + 1;
        end
        
        loops = loops + 1;
    end
    
    results(i,1) = i;
    results(i,2) = loops;
end

temp = results;
temp(1:end, 1) = 0;

[x,y] = ind2sub(size(results), find(temp == max(max(temp))));

solution = x;

clc
fprintf('Solution: %d\n', solution);

