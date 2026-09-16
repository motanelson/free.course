In the 2000s, the situation looked roughly like this:
Windows CE was a Microsoft operating system designed to run on various types of processors.
Microsoft created an abstraction layer for each architecture/processor—called the OEM Adaptation Layer (OAL)—in addition to platform-specific code.
ARM was a licensable CPU architecture. Companies like Intel, Samsung, Motorola/Freescale, Texas Instruments, etc., could manufacture ARM-based processors.
Motorola also manufactured CPUs that could feature different architectures, including the 68K family, PowerPC, and—in certain products—ARM.
Therefore, there wasn't necessarily just one C source code for ARM and another for Motorola that were then “transformed” into Windows CE.
A simple way to visualize it:
                 Microsoft
                     │
              Windows CE
                     │
          ┌──────────┼──────────┐
          │          │          │
        ARM        MIPS       SH/SH3
          │          │          │
       ARM CPU    MIPS CPU    SuperH CPU
          │          │          │
       hardware   hardware    hardware
The same Windows CE could be compiled for different architectures. The system's common code was largely C/C++ and assembly, but there were parts specific to the architecture and the hardware.
And where does ARM fit in?
ARM didn't usually just sell a finished processor. The company developed and licensed processor intellectual property (IP), such as ARM cores.
For example:
ARM
 │
 ├── develops ARM architecture/core
 │
 └── licenses the IP
        │
        ├── Samsung
        ├── Texas Instruments
        ├── Motorola/Freescale
        ├── Intel (during certain periods/products)
        └── other companies
These companies could then build their own ARM-based SoCs/processors, complete with peripherals, memory, controllers, etc.
And what about C?
Here is the part that is likely causing the confusion.
A processor does not “execute C” directly.  For example:
C code
   ↓
Compiler
   ↓
ARM machine code
   ↓
ARM CPU executes
For another processor:
C code
   ↓
MIPS compiler
   ↓
MIPS machine code
   ↓
MIPS CPU executes
Therefore, the fact that Windows CE had a lot of code written in C/C++ did not mean that the same binary code could run on any processor.
The source code could be reused, but it had to be compiled for the specific architecture, and some parts had to be adapted.
And were there really several competing processors?
Yes. And that is one of the interesting things about Windows CE.
At the beginning and throughout much of Windows CE's history, Microsoft supported architectures such as:
ARM
MIPS
SuperH (SH)
x86
Thus, two devices could run Windows CE yet be quite different internally:
        Windows CE
             │
       ┌─────┴─────┐
       │           │
    ARM CE      MIPS CE
       │           │
   Processor  ​​   Processor
      ARM          MIPS
       │           │
    PDA A        PDA B
Windows CE provided a sort of common platform, while different manufacturers chose different CPUs.
And there is also an important nuance: Motorola was not equivalent to ARM. ARM was primarily a CPU architecture/IP, whereas Motorola was a company that designed and manufactured various processor families. At certain times, a company might even manufacture an ARM-based processor.

Linux already existed on these mobile devices and in embedded systems. What happened was that, in the 1990s and early 2000s, Linux lacked the commercial presence and ecosystem that Windows CE enjoyed on PDAs and mobile devices.
The difference boils down to this:
1. Windows CE was designed from the start for small-scale hardware
Microsoft created Windows CE specifically for resource-constrained devices:
ARM / MIPS / SH / x86 CPU
          ↓
      Windows CE
          ↓
 ┌────────┼────────┐
 APIs   drivers   services
          ↓
   OEM applications
A manufacturer could buy or license Windows CE and adapt the necessary components to their specific hardware.
This was highly attractive to manufacturers of PDAs, GPS units, industrial terminals, and so on.
2. Linux could do practically the same thing
Linux is a kernel that can also be compiled for various architectures.
For example:
             Linux
               │
       ┌───────┼────────┐
       ↓       ↓        ↓
      ARM     MIPS     x86
       ↓       ↓        ↓
     SoC A   SoC B    CPU C
And Linux was already running on ARM and MIPS long before modern smartphones arrived.
The problem wasn't simply:
"Linux didn't exist."
It was more a case of:
"There was no standardized mobile Linux platform with the tools, drivers, graphical interfaces, and commercial support comparable to Windows CE."
3. What about C libraries?
You’re touching on a very important point here.
In Linux, there is typically a chain that looks like this:
C application
    ↓
C libraries
    ↓
system calls
    ↓
Linux kernel
    ↓
driver
    ↓
CPU / hardware
C libraries can be compiled for ARM, MIPS, x86, etc.
For instance, a library like libc might have one implementation for ARM and another for MIPS.
However, a library compiled for ARM cannot automatically run on MIPS.  It’s the same idea:
same C source code
       │
       ├── ARM compiler → ARM binary
       │
       └── MIPS compiler → MIPS binary
4. So why did Windows CE gain traction?
Because Microsoft provided manufacturers with a relatively integrated package:
kernel
APIs
libraries
file system
device support
development tools
graphical environment
documentation
commercial support
mechanisms for manufacturers to create their own system images
The manufacturer could say:
"I have this ARM processor, this screen, this storage controller, and these peripherals."
And build a specific Windows CE image for that device.
5. But Linux was on servers!
Exactly—and here lies an interesting historical distinction.
On servers, Linux had a very strong trajectory because server hardware was relatively standardized, especially x86.
x86 server
     ↓
   Linux
     ↓
Apache / databases / etc.
With a PDA from that era, the situation was much more fragmented:
PDA A → ARM + proprietary hardware
PDA B → MIPS + different hardware
PDA C → SH + different hardware
PDA D → ARM + another SoC
Each manufacturer had to put much more effort into integration.
6. And later, that changed completely
The most interesting part is that Linux ended up dominating the mobile/embedded world precisely through an evolution that led to systems like:
Linux kernel
     ↓
Android
     ↓
smartphones / tablets / TVs / cars / IoT
In other words, it wasn't a fundamental limitation of Linux.
It was primarily a matter of ecosystem, manufacturer support, drivers, tools, APIs, and the business model.  And there is a huge historical difference between Windows CE/Pocket PC, embedded Linux, Symbian, and later systems. If you really want to understand what happened, I can explain the evolution from 1995 to 2010—covering ARM, Windows CE, Linux, Symbian, Palm, and Android—and why the market ultimately converged on ARM and Linux.



