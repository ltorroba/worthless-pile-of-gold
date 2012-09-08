% List all primes from 1 to 'limit'
limit = 600851475143;
primes = [2,3];
candidate = 0;
lastPrime = 0;

for i=4:limit
    for j=1:max(size(primes))
        if(mod(i,primes(1,j))==0)
            % Can't be prime -> break
            break
        end
        
        if(primes(1,j)==primes(1,max(size(primes))))
            % Must be prime -> Push and break
            primes(1,max(size(primes))+1) = i;
            
            if(candidate==0)
                if(mod(limit, i)==0)
                    % Divisible, see if other is prime
                    prime = limit/i;                    
                    candidate = prime;
                    lastPrime = i;
                    disp('last prime');
                    disp(lastPrime);
                end
            else
               if(mod(candidate, i)==0)
                   candidate = candidate/i;
                   lastPrime = i;
                   disp('last prime');
                   disp(lastPrime);
               end
            end
        end
    end
end

disp('done')

% 6857 is correct