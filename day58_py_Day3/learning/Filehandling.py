# File hadling in python
#  file modes in python read(r), write(w), append(a), read and write(r+), write and read(w+), append and read(a+)

#  open data.txt file in read mode

f = open('C:/Users/VC/codestack/GenSpark/day58_py_Day3/learning/data.txt', 'r')
print(f.read())
f.close()

#  open data.txt file in append mode

f = open('C:/Users/VC/codestack/GenSpark/day58_py_Day3/learning/data.txt', 'a')
f.write('Hello World')
f.close()

#  open data.txt file in write mode

f = open('C:/Users/VC/codestack/GenSpark/day58_py_Day3/learning/data.txt', 'w')
f.write('Hello World')
f.close()


#  open data.txt file in read mode

f = open('C:/Users/VC/codestack/GenSpark/day58_py_Day3/learning/data.txt', 'r')
print(f.read())
f.close()

