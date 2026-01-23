small devices:
https://www.oracle.com/java/technologies/javameoverview.html#sdk

open java:
https://wiki.debian.org/Java


Software Layers: From ROM and BIOS to Virtual Machines
Modern computing systems are built using multiple layers of software, each one responsible for a specific role in the startup process, hardware management, and application execution. Understanding these layers helps clarify how devices boot, operate, and run complex software efficiently, from small embedded systems to powerful servers and mobile devices.
1. ROM and BIOS: The Foundation Layer
At the very base of the software stack is ROM (Read-Only Memory), which typically contains firmware such as the BIOS (Basic Input/Output System) or UEFI on modern systems.
This layer is tightly coupled with the hardware and is responsible for:
Initializing essential hardware components (CPU, memory, storage, peripherals)
Performing basic hardware checks
Providing the first instructions executed when the device is powered on
Because this firmware resides in non-volatile memory, it remains available even when the device is powered off. It represents the most fundamental software layer in the system.
2. Bootloader: Managing the Startup Process
Above the BIOS or firmware layer comes the bootloader. The bootloader is a small but critical piece of software that takes control after the firmware finishes its initialization tasks.
Its main responsibilities include:
Locating and loading the operating system kernel into memory
Managing multiple boot options or operating systems
Handling disk partitions and boot configurations
Common examples include GRUB, U-Boot, and LILO, depending on the platform. In embedded or mobile devices, the bootloader is often customized to manage limited resources and secure boot processes.
3. Operating System Layer: Linux or Other OS
Once the bootloader hands over control, the operating system (OS) takes charge. This layer acts as an intermediary between hardware and applications.
In many systems, especially servers, embedded devices, and Android-based platforms, Linux is the operating system of choice. The OS is responsible for:
Process and memory management
Device drivers and hardware abstraction
File systems and networking
Security and user management
The operating system defines the environment in which all higher-level software runs.
4. Native Software Layer: C and Low-Level Applications
On top of the operating system, we find native software, often written in C or C++. These applications interact closely with the OS and sometimes directly with hardware through system calls.
This layer is common in:
System utilities
Embedded software
Performance-critical applications
Native code provides high efficiency and low resource usage, which is especially important for small or resource-constrained devices.
5. Virtual Machines and Managed Runtimes
The highest software layer often consists of virtual machines (VMs) or managed runtime environments. These platforms abstract the underlying OS and hardware, allowing applications to be portable across different systems.
Examples include:
Java Virtual Machine (JVM) for Java applications
Android Runtime (ART) for Android devices
.NET / Mono for cross-platform managed applications
The choice of virtual machine or runtime depends on:
Device size and hardware capacity
Performance requirements
Application ecosystem and portability needs
On small embedded systems, virtual machines may be avoided due to limited resources, while on larger devices such as smartphones, desktops, and servers, they offer flexibility, security, and faster development.
Conclusion
Software systems are structured in layers, each building upon the previous one. From the firmware stored in ROM, through the bootloader and operating system, up to native applications and virtual machines, each layer plays a crucial role.
This layered architecture allows systems to scale across a wide range of devices, from minimal embedded controllers to complex, high-performance computing platforms, adapting the software stack to the capabilities and requirements of each device.
👍
