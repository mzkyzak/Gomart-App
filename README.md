## 🚀 Versi Ringan & Efisien

* 🖥️ **Visual Studio and notepad** → mengedit code aplikasi C#
* 🗄️ **SQL Server Management Studio** → mengelola database

---

# 🛒 Gomart App (C# WinForms + SQL Server)

Aplikasi desktop sederhana berbasis **C# WinForms** yang menggunakan **LINQ to SQL** dan **Microsoft SQL Server**.
Project ini dibuat berdasarkan modul training (ITTSB) dan mendukung fitur CRUD serta autentikasi login dengan enkripsi SHA256.

---

## 🚀 Fitur Utama

* 🔐 Login dengan enkripsi **SHA256**
* 📊 CRUD Data Member (Create, Read, Update, Delete)
* 🔍 Pencarian data secara realtime
* 🆔 Auto Generate ID (format: `M2026xxxxx`)
* 🖥️ Multi Document Interface (MDI Form)
* 🔗 Koneksi database menggunakan LINQ to SQL

---

## 🛠️ Tools & Teknologi

* **C# WinForms (.NET Framework)**
* **Microsoft SQL Server (LocalDB / SSMS)**
* **LINQ to SQL**
* **Visual Studio (VC#)**

---

## 📂 Struktur Project

```
gomart/
│
├── Program.cs
├── LoginForm.cs
├── MainForm.cs
├── MemberForm.cs
├── DataClass.cs
├── App.config
├── DataClasses.dbml
```

---

## ⚙️ Cara Menjalankan Project

### 1. Setup Database

Buka **SQL Server Management Studio (SSMS)**, lalu jalankan script berikut:

```sql
CREATE DATABASE gomart;
GO
USE gomart;

CREATE TABLE Member(
 Id VARCHAR(10) PRIMARY KEY,
 Name VARCHAR(255),
 Email VARCHAR(50),
 PhoneNumber VARCHAR(20)
);

CREATE TABLE Position(
 Id INT IDENTITY PRIMARY KEY,
 Name VARCHAR(50)
);

CREATE TABLE Employee(
 Id INT IDENTITY PRIMARY KEY,
 Email VARCHAR(50),
 Password VARCHAR(255),
 PositionId INT
);

-- Password sudah di-hash SHA256 dari '123'
INSERT INTO Employee VALUES 
('admin@gmail.com','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07f4b7f5f5e8f7f7f5b',1);
```

---

### 2. Buka Project di Visual Studio

1. Buka **Visual Studio**
2. Klik **Open Project/Solution**
3. Pilih file `.sln`

---

### 3. Setup LINQ (.dbml)

1. Klik kanan project → **Add → New Item**
2. Pilih **LINQ to SQL Classes (.dbml)**
3. Drag tabel:

   * `Member`
   * `Employee`
   * `Position`

---

### 4. Cek Koneksi Database

Pastikan di `App.config`:

```xml
<connectionStrings>
  <add name="lksConnectionString"
       connectionString="Data Source=(localdb)\MSSQLLocalDB;
       Initial Catalog=gomart;
       Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

---

### 5. Jalankan Aplikasi

* Tekan **F5** atau klik **Start**
* Aplikasi akan menampilkan halaman login

---

## 🔐 Akun Login Default

```
Email    : admin@gmail.com
Password : 123
```

---

## 📸 Tampilan Aplikasi

* Login Form
* Main Menu (MDI)
* Member Form (DataGridView + CRUD)

---

## ⚠️ Catatan Penting

* Pastikan SQL Server aktif
* Jangan lupa membuat file `.dbml`
* Jangan upload folder `bin/` dan `obj/` ke GitHub
* Gunakan `.gitignore` untuk project C#

---

## 👨‍💻 Author

* Nama: mzkyzak
* Project: Gomart C# WinForms

---

## ⭐ Penutup

Project ini cocok untuk:

* Tugas sekolah / pembelajaran
* Latihan CRUD dan database menggunakan C#
