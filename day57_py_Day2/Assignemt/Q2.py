# 2) Print the list of prime numbers up to a given number

def prime_numbers(n):
    prime = []
    for num in range(2,n+1):
        for i in range(2,num):
            if num % i == 0:
                break
        else:
            prime.append(num)
    return prime

print(prime_numbers(10)) 