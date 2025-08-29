import os
import shutil
import tkinter as tk
from tkinter import messagebox
from pathlib import Path
import customtkinter as ctk

ctk.set_appearance_mode("dark")
ctk.set_default_color_theme("blue")


def clear_folder(folder_path, folder_name):
    try:
        folder = Path(folder_path)
        if not folder.exists():
            messagebox.showerror("Error", f"{folder_path} does not exist.")
            return
        for item in folder.iterdir():
            try:
                if item.is_file():
                    item.unlink()
                elif item.is_dir():
                    shutil.rmtree(item)
            except Exception as e:
                print(f"Failed to delete {item} : {e}")

        messagebox.showinfo("Done!", f"Files in {folder_name} have been deleted.")
    except Exception as e:
        messagebox.showerror("Error", str(e))

#clean %temp%
def clear_temp():
    temp_path = os.environ.get('TEMP')
    clear_folder(temp_path, 'temp')

#clean prefetch
def clear_prefetch():
    prefetch_path = r"C:\Windows\Prefetch"
    clear_folder(prefetch_path, 'prefetch')

#window
app = ctk.CTk()

app.title("Temp Cleaner")
app.geometry("300x300")

#temp btn
btn_temp = ctk.CTkButton(
                        master=app, 
                        text="CLEAR TEMP",
                        corner_radius=72,
                        width=200, 
                        height=42,
                        font=("Arial", 16, "bold"),
                        command=clear_temp
                        )
btn_temp.place(relx=0.5, rely=0.4, anchor=tk.CENTER)

#prefetch btn
btn_pre = ctk.CTkButton(
                        master=app, 
                        text="CLEAR PREFETCH",
                        corner_radius=72, 
                        width=200, 
                        height=42,
                        font=("Arial", 16, "bold"),
                        command=clear_prefetch
                        )
btn_pre.place(relx=0.5, rely=0.6, anchor=tk.CENTER)

app.mainloop()