% find the largest palindrome within given range min:max
min = 100*100;
max = 999*999;

solutions = [];

for i=1:999 % use 1000 - i
   for j=1:999 % use 1000 - j
       num = (1000-i)*(1000-j);

       arr = sscanf(sprintf('%d', num), '%1d');
       
       works = true;
       
       for x=1:floor(length(arr)/2)
           if(arr(x) ~= arr(length(arr)-x+1))
               works = false;
               break;
           end
       end
       
       if(works)           
           disp('Largest palindrome: ' + num);
           disp('(' + i + ' * ' + j + ')');
           solutions(1,length(solutions)+1) = num;
           solutions(2,length(solutions)+1) = i;
           solutions(3,length(solutions)+1) = j;
           break;
       end       
   end
end