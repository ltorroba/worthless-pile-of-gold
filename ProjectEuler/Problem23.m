% Problem 23 - Abundant Numbers
bound = 28123;

A = zeros(1,bound);
factors = [];
derivates = [];
total = 0;
nonderivates = [];
nonderivates2 = [];
nonfiltered = [];
filtered = [];

clc;

tic

% Build array of all abundant numbers
for i=1:bound
    total = 0;
    
    % Get prime factors    
    for j=1:sqrt(i)
       if mod(i,j)==0          
          if j == sqrt(i)
              total = total + j;
          else          
              total = total + j + i/j;
          end
       end
    end
    
    % Check to see if abundant
    if i < total
       % Abundant!
       A(i) = i;
    end
end

% Filter
A = find(A);

derivates = zeros(length(A));

% Make list of all numbers, derived from the sum of 2 abundant numbers
for j=1:length(A)
   for k=1:length(A)
       derivates(j,k) = A(j) + A(k);
   end
end

% Filter (remove dupes and zeros)
derivates = unique(derivates);

% Get sum
total = 0;

for l=1:length(derivates)
    if ~any(derivates==l)
        total = total+i;
    end
end

% Print result
fprintf('Sum of numbers not made up from the sum of 2 abundant numbers below %d: %d\n', bound, total);

toc
