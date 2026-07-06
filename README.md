# Holiday Management System (Szabadságoló Alkalmazás)

A specialized enterprise web application tailored for Hungarian Vocational Education Centers (*Szakképzési Centrumok*) to efficiently track, calculate, and manage annual leave for all educational and operational staff—including teachers (*oktatók*), technical caretakers (*technikai dolgozók*), and school principals (*intézményvezetők*).

[![Figma Design](https://img.shields.io/badge/Design-Figma-F24E1E?style=flat&logo=figma&logoColor=white)](https://www.figma.com/board/rSFvcEDbflhZfikIr5f3Jh/Szabads%C3%A1gol%C3%B3-Alkalmaz%C3%A1s?node-id=0-1&p=f&t=EgNp1lEQF38RHN1F-0)
![Tech Stack](https://img.shields.io/badge/Stack-.NET%20Blazor%20%7C%20MS%20SQL-512BD4?style=flat)

---

## 📌 Problem Statement & Context

In the Hungarian public education and vocational training sectors (*Szakmaszervezeti és Köznevelési rendszerek*), employee holiday allocation follows strict statutory regulations (such as the Labor Code (*Mt.*) or specific status laws like *Státusztörvény*). 

Crucially, **the vast majority of teacher holidays are mandatory during the summer break** and seasonal school holidays. Education centers struggle to manually calculate:
1. Exactly how many base and extra days (*pótszabadság*) each role possesses.
2. Managing the remaining few days left over for individual use outside the mandatory collective summer block.
3. Keeping a strict log across dozens of institutions (*szakképző intézmények*) under a single central administration.

This system centralizes and automates this workflow, eliminating human error in legal calculations.

---

## 🗺️ Early Planning & Architecture

The workflow, security roles, calculation rules, and user interfaces were completely modeled beforehand. 

* **Complete System Blueprint:** You can inspect the structure, role trees, calculation variables, and project management scope on the **[Figma Board](https://www.figma.com/board/rSFvcEDbflhZfikIr5f3Jh/Szabads%C3%A1gol%C3%B3-Alkalmaz%C3%A1s?node-id=0-1&p=f&t=EgNp1lEQF38RHN1F-0)**.

---

## ⚙️ Key Features

* **Role-Based Leave Allocations:** Differentiated base and extra leave rules based on job categories:
  * *Oktatók / Pedagógusok* (Typically entitled to 50 days of basic+educational extra leave).
  * *Technikai / Adminisztratív munkatársak* (Calculated by age/children under standard *Mt.* guidelines).
  * *Intézményvezetők* (Additional leadership extra days).
* **Automated Summer Block Booking:** Bulk allocation of days to match the institutional summer break schedule.
* **Remaining Days Tracker:** Real-time countdown counters per employee indicating legally accurate remaining days.
* **Approval Workflow:** Streamlined process for staff to request individual leave days and for principals/HR to approve them online.
* **Centralized Data:** Gives Center-level management (*Centrum vezető*) clear high-level reports while allowing individual school principals to handle their local teams.

---

## 🛠️ Technical Stack

This project is a single-developer application designed for high performance, ease of deployment, and tight integration with Microsoft-heavy enterprise environments typical of public services.

* **Frontend & Backend:** **Blazor** (C# .NET) utilizing a component-driven SPA architecture.
* **Database:** **Microsoft SQL Server (MSSQL)** for robust relational consistency, secure transactions, and enterprise logging.
* **Data Access:** Entity Framework Core (EF Core) for strongly-typed Object-Relational Mapping.

---

## 🗂️ Database Overview (Core Concepts)

<img width="1061" height="546" alt="image" src="https://github.com/user-attachments/assets/4ac37bbd-b562-40e0-8858-32bca6dedf86" />

## 📄 License
This project is proprietary software designed for specific Hungarian educational administrative frameworks. All rights reserved.
