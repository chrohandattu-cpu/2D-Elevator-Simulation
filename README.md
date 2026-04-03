# **2D Elevator Simulation – Project Report**

## **1. Overview**

This project involves the development of a **2D Elevator Simulation system** using Unity Engine. The goal was to design a system where multiple elevators respond intelligently to floor requests, mimicking real-world elevator behavior while maintaining clean architecture and scalable logic.

---

## **2. Objectives Achieved**

* Implemented a system with **3 independent elevators**
* Designed **4-floor structure (Ground, 1, 2, 3)**
* Created **interactive UI buttons** for floor requests
* Developed a **centralized elevator dispatch system**
* Ensured **smooth elevator movement (no teleportation)**
* Displayed **real-time floor status for each elevator**

---

## **3. System Architecture**

The project is divided into three main components:

### **3.1 Elevator (Individual Unit)**

Each elevator operates independently and maintains:

* Current floor tracking
* Request queue system
* Direction state (Up / Down / Idle)
* Smooth movement logic

### **3.2 Elevator Manager (Dispatcher)**

A centralized system responsible for:

* Handling incoming floor requests
* Selecting the **most optimal elevator**
* Preventing multiple elevators from responding to the same request

### **3.3 UI System**

* Floor call buttons for each floor
* Real-time display of elevator positions
* User interaction layer connected to backend logic

---

## **4. Key Functionalities Implemented**

### **4.1 Smart Elevator Selection**

* The nearest elevator is selected based on:

  * Distance from requested floor
  * Current direction of movement
  * Idle state priority
* Elevators moving in the **correct direction are prioritized**
* Elevators moving in the **wrong direction are penalized**

---

### **4.2 Independent Request Queues**

* Each elevator maintains its own queue
* Duplicate requests are avoided
* Requests are processed in sequence

---

### **4.3 Direction-Based Logic**

* Elevators dynamically update direction:

  * Moving Up
  * Moving Down
  * Idle when no requests
* Ensures realistic movement behavior

---

### **4.4 Edge Case Handling**

Special attention was given to:

* **Same Floor Request Issue**

  * If an elevator is already at the requested floor and idle:

    * It is skipped during selection
    * Another nearest elevator is assigned
  * Optional: Door open simulation can be triggered

---

### **4.5 Smooth Movement System**

* Movement is restricted to **Y-axis only**
* Implemented using `Mathf.MoveTowards`
* Added:

  * Axis locking (prevents horizontal drift)
  * Final position snapping (avoids floating-point errors)

---

### **4.6 Multi-Elevator Coordination**

* Ensures:

  * No duplicate responses
  * Efficient distribution of requests
  * Balanced usage of elevators

---

## **5. Technical Highlights**

* Clean and modular C# scripts
* Use of:

  * Coroutines for smooth movement
  * Queues for request handling
  * Enums for state management
* Scalable structure (can easily extend to more elevators/floors)

---

## **6. Code Structure Focus**

* Separation of concerns:

  * Elevator logic is independent
  * Manager handles decision-making
  * UI only triggers actions
* Avoided tightly coupled systems
* Designed for easy debugging and expansion

---

## **7. Additional Considerations**


https://github.com/user-attachments/assets/200d98b1-8cce-40d3-970e-ee5cabd3ae35


### Improvements that can be added:

* Door animation system (open/close)
* Advanced scheduling (SCAN / LOOK algorithms)
* Inside elevator button panels
* Sound effects and polish
* Performance optimization for larger systems

---

## **8. Conclusion**

This project successfully demonstrates:

* Strong understanding of **Unity fundamentals**
* Ability to design **real-world system logic**
* Clean and scalable **code architecture**
* Effective handling of **edge cases and user interaction**

The system is functional, extensible, and reflects practical elevator behavior, making it suitable for both gameplay and simulation-based applications.

---
