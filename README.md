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
