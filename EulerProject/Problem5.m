% Finds the first number that is divisible by all of the numbers
% in the 'y' array.
x = 1;
z = 0;
y = [11, 13, 14, 16, 17, 18, 19, 20];
while z==0
    %disp(x);
for i=1:max(size(y))
if(mod(x,y(1,i))>0)
    break
end
%disp(y(1,i))
if(y(1,i)==y(1,max(size(y))))    
    z=x;
end
end
    x=x+1;
if(z>0)
    disp('Solution found: '+z);
    break
end
if(mod(x,200000)==0)
    disp(x);
end
end
