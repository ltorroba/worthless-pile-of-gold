% Thue-Morse Problem (Problem 361)
% http://projecteuler.net/problem=361

% In order to solve this problem, we will iterate through every integer,
% until we obtain all the values of A(10^k) where 0 <= k <= 18

% We'll use the strfind() function to check if the integer's binary
% representation can be found in T.

% In order to conserve memory and time, for any A(n), we'll only
% use T to 2^floor(log2(x)) digits. 

% We'll also always check for 3 consecutive bits of identical value (e.g.:
% 111 and 000), as their presence already certifies that this integer
% cannot be found in the set A.

% TODO: Matrix preallocation

bound = 1; % to what n should A(n) be calculated

A = []; % Holds integers contained in T
T = [0, 1]; % Current binary representation of T, in a matrix
Ts = char(T+'0'); % Current binary representation of T, in a string
n = 0; % Current testing index

terminate = false; % Termination flag

% Start loop, where n equals
while ~terminate
    % Check if T doesn't have required length
    if(log2(n)==floor(log2(n+1)))
        % Expand the length of T by 2*length(T)
        T = [T, ones(1,length(T))-T];
        Ts = char(T+'0');
        %Ts = fprintf(['%d','%d'], T);
    end
    
    % Check for 3 consecutive identical bits in integer
    if(length(strfind(dec2bin(n), '000')) >= 1 || length(strfind(dec2bin(n), '111')) >= 1)
        % Discard index
        n = n+1;
    else
        % Check if integer is found in T
        if(length(strfind(Ts, dec2bin(n))) >= 1)
            A(1,length(A)+1) = n;
            str = sprintf('A(%d): %d', length(A)-1, n);
            disp(str);
        end

        % Terminate if bound is reached
        if(length(A) >= bound+1)
           terminate = true; 
        end

        % Increment n
        n = n+1;
    end
end