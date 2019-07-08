import sys
import MeCab
import random
import pprint
import csv

print("どこに住んでますか？")

f = open('Nounplace.csv')

rand = random.randint(1, 10000)

reader = csv.reader(f)
l = [row for row in reader]

print(">", end="")
print("私は", end="")
print(" " + l[rand][0] + " ", end="") #乱数による行場所指定(N行 1列(プログラムでは0))
print("に住んでいます")


