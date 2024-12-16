set -e # Exit if any command fails
a=()
b=()
while read -r first second; do
    a+=($first)
    b+=($second)
done < day1.txt

as=($(printf '%s\n' ${a[@]} | sort -n ))
bs=($(printf '%s\n' ${b[@]} | sort -n ))

# Part 1 solution
ans=0
for ((i=0; i < ${#as[@]}; i+=1)); do
    tmp=$((as[i] - bs[i]))
    if [ $tmp -lt 0 ]; then
        tmp=$((tmp * -1))
    fi
    ans=$(($ans + $tmp))
done

echo $ans
