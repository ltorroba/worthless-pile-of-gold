% Problem 18
% Where triangle is the triangle of digits, in an array. 
curr = 0;
newtrig = triangle;

clc;

% Go to last row
for i=1:length(triangle)
    curr = (length(triangle)-i)+1;
    
    % Loop through row
    for index=1:curr-1
        if newtrig(curr,index) >= newtrig(curr, index+1)
           newtrig(curr-1,index) = newtrig(curr,index) + newtrig(curr-1,index);
        else
           newtrig(curr-1,index) = newtrig(curr,index+1) + newtrig(curr-1,index);
        end
    end
end

fprintf('Solution is: %d\n', newtrig(1,1));