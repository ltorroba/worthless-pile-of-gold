% Problem 11 - Greatest product of 4 diagonal numbers
rightdown = zeros(17, 17);
rightup = zeros(17,17);
leftdown = zeros(17,17);
leftup = zeros(17,17);
up = zeros(17,17);
right = zeros(17,17);
down = zeros(17,17);
left = zeros(17,17);

% NOTE: Map is the array which has been manually added to Matlab, by
% importing it into Excel and then pasting it into a matrix in Matlab,
% using the 'Paste Excel' option
for x=4:23
   for y=4:23
      rightdown(x,y) = map(x,y)*map(x+1,y+1)*map(x+2,y+2)*map(x+3,y+3);
      rightup(x,y) = map(x,y)*map(x+1,y-1)*map(x+2,y-2)*map(x+3,y-3);
      leftdown(x,y) = map(x,y)*map(x-1,y+1)*map(x-2,y+2)*map(x-3,y+3);
      leftup(x,y) = map(x,y)*map(x-1,y-1)*map(x-2,y-2)*map(x-3,y-3);
      up(x,y) = map(x,y)*map(x,y-1)*map(x,y-2)*map(x,y-3);
      down(x,y) = map(x,y)*map(x,y+1)*map(x,y+2)*map(x,y+3);
      left(x,y) = map(x,y)*map(x-1,y)*map(x-2,y)*map(x-3,y);
      right(x,y) = map(x,y)*map(x+1,y)*map(x+2,y)*map(x+3,y);
   end
end

% Obtain the individual maximum out of all arrays
candidates = [max(max(rightdown)),max(max(rightup)),max(max(leftdown)),max(max(leftup))
    max(max(up)),max(max(right)),max(max(down)),max(max(left))];

solution = max(max(candidates));