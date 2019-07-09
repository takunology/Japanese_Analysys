import sys
import tkinter as tk
from tkinter import messagebox as mbox

# GUI 処理
window = tk.Tk()
window.title("簡単なアプリ")
window.geometry("400x300")

#ラベル
label = tk.Label(window, text="入力")
label.pack

#テキストボックス
textbox = tk.Entry(window)
textbox.pack()
textbox.insert(tk.END,"")

#ボタン処理
text = ""
def On_Click():
    text = textbox.get()
    mbox.showinfo("メッセージタイトル", text)

#ボタン作成
OK_Button = tk.Button(window, text="入力", command=On_Click)
OK_Button.pack()

window.mainloop()