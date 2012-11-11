% Problem 21 - Sum of amicable pairs under 10000
amicables = [];
bound = 10000;
f1 = [];
f2 = [];
sum1 = 0;
sum2 = 0;

clc;

for i=2:bound
    if isempty(find(amicables==i))
        f1 = [];
        f2 = [];
        sum1 = 0;
        sum2 = 0;

        % Find factors of index (exclude the number itself)
        max1 = ceil(sqrt(i));

        for j=1:max1-1
            if mod(i,j) == 0
                f1(length(f1)+1) = j;

                if j~=i && j~=1
                   f1(length(f1)+1) = i/j; 
                end
            end
        end

        % Add factors up
        sum1 = sum(f1);

        % Find factors of sum 
        max2 = ceil(sqrt(sum1));

        for k=1:max2-1
           if mod(sum1,k)==0
              f2(length(f2)+1) = k;

              if k~=sum1 && k~=1
                 f2(length(f2)+1) = sum1/k; 
              end
           end
        end

        % Add factors up²
        sum2 = sum(f2);

        % Compare
        if sum2==i && sum1~=i
           % It's an amicable pair!
           amicables(length(amicables)+1) = i;
        end
    end
end

fprintf('Sum of all amicables below %d: %d\n', bound, sum(amicables));