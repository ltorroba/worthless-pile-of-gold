% Problem 10 - Sum of all primes below a million
primes = [2,3]; % define list
n = 4;
bound = 2000000;
%bound = 20;

while n < bound
    isprime = true;
    
    for i=1:length(primes)        
        if(mod(n,primes(i)) == 0)
            isprime = false;
            break;
        end           
    end
    
    if(isprime)
       primes(length(primes)+1) = n; 
       
       %disp(sprintf('P(%d): %d', length(primes), n));
    end
    
    if(mod(n,100000) == 0)
       clc;
    end
    
    n = n+1;
end

solution = sym(sum(primes));