% Problem 19 - Calendar problem
first = 6; % Day of first stunday in starting year
firstdays = [];
sundays = [];

lowbound = 1901;
bound = 2000;
prev = 1;

counter = 0;

clc;

for year=lowbound:bound
    firstdays = [];
    sundays = [];
    prev = 1;
    
    % Is leap?
    if mod(year, 4) == 0
       isleap = 1; 
    else
       isleap = 0;
    end

    % Build first days
    firstdays(1) = 1;

    for m=1:11
        if m == 2
            if mod(year, 4) == 0
               % Leap
               firstdays(m+1) = prev + 29;
            else
               % Not leap
               firstdays(m+1) = prev + 28;
            end
        else
            if m <= 7
                if mod(m,2) == 0
                    firstdays(m+1) = prev + 30;
                else
                    firstdays(m+1) = prev + 31;
                end
            else
                if mod(m,2) == 0
                    firstdays(m+1) = prev + 31;
                else
                    firstdays(m+1) = prev + 30;
                end
            end
        end

        prev = firstdays(m+1);
    end

    % Build sundays
    for s=1:(floor((firstdays(length(firstdays))+30-first)/7))+1
        if s == 1
           sundays(s) = first; 
        else
           sundays(s) = sundays(s-1) + 7;
        end
    end

    % Get number of intersects
    counter = counter + length(intersect(sundays, firstdays));
    
    % Calculate next first sunday
    lastsunday = sundays(length(sundays));
    
    if isleap == 1
        % Is leap
        first = lastsunday - 366;
    else
        % Isn't leap
        first = lastsunday - 365;
    end
end

fprintf('Number of Sundays between %d and %d: %d\n', lowbound, bound, counter);