x = input('入力よ→ ')
file = open('SaveFile\\InputText.txt', 'w')
file.write(x)
file.close()