import os
import shutil
import tkinter as tk
from tkinter import messagebox
from pathlib import Path


def clear_folder(folder_path, folder_name):
    try:
        folder = Path(folder_path)
        if not folder.exists():
            messagebox.showerror("錯誤", f"{folder_path} 不存在")
            return
        for item in folder.iterdir():
            try:
                if item.is_file():
                    item.unlink()
                elif item.is_dir():
                    shutil.rmtree(item)
            except Exception as e:
                print(f"刪除 {item} 失敗: {e}")

        messagebox.showinfo("清理完成", f"已成功清理{folder_name}資料夾")
    except Exception as e:
        messagebox.showerror("錯誤", str(e))

#clean %temp%
def clear_temp():
    temp_path = os.environ.get('TEMP')
    clear_folder(temp_path, 'temp')

#clean prefetch
def clear_prefetch():
    prefetch_path = r"C:\Windows\Prefetch"
    clear_folder(prefetch_path, 'prefetch')

#window
root = tk.Tk()
root.title("暫存檔清理工具")
root.geometry("300x200")

btn_temp = tk.Button(root, text="清理 temp", command=clear_temp, width=20, height=2)
btn_temp.pack(pady=30)

btn_prefetch = tk.Button(root, text="清理 prefetch", command=clear_prefetch, width=20, height=2)
btn_prefetch.pack(pady=5)

root.mainloop()