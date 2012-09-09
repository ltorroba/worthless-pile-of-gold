% Problem 9 - Pythagorean triple

solution = -1;

for a=1:1000
   for b=1:1000
       c = sqrt(a^2+b^2);
       
       % Check if c is whole number (perfect square)
       if(~mod(c,1))
           if(a+b+c==1000)
               solution = a*b*c;
               disp('Solution: ' + solution);
               break;
           end
       end
   end
   
   if(solution > -1)
      break; 
   end
end