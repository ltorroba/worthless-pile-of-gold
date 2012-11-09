% Problem 15 -  the squares thingy
xdim = 20;
ydim = 20;

components = zeros(xdim, 1);
components_temp = zeros(xdim, 1);
summation = 0;
cumulative = 1; % 1, as we have to include the null path (going through the left border)

clc;

% Build component matrix
for i=1:xdim
   components(i) = 1; 
end

% Loop till 20 cols
for j=1:ydim
   % Add component matrix
   summation = sum(components);
   
   % Generate new matrix
   components_temp(1) = summation;
   
   for k=2:xdim
      components_temp(k) = components_temp(k-1)-components(k-1);
   end
   
   % Update matrix
   components = components_temp;
   
   % Update cumulative
   cumulative = sym(cumulative + summation);
   
   % Print curr result
   fprintf('Total paths in %d by %d grid: %s\n', xdim, j, char(cumulative));
end