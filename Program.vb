Imports System.IO
Imports System.Text

Module WasmGenerator
    Sub Main()
        Console.Clear()
        Console.BackgroundColor = ConsoleColor.DarkYellow
        Console.ForegroundColor = ConsoleColor.Black
        Console.WriteLine(vbCrLf & "Criando ficheiro main.wasm..." & vbCrLf)

        Using fs As New FileStream("main.wasm", FileMode.Create, FileAccess.Write)
            Using writer As New BinaryWriter(fs)

                ' Cabeçalho
                writer.Write(New Byte() {&H0, Asc("a"c), Asc("s"c), Asc("m"c)})
                writer.Write(New Byte() {&H1, &H0, &H0, &H0})

                ' Seção de tipos
                writer.Write(CByte(&H1))      ' id da seção: type
                writer.Write(CByte(&H7))      ' tamanho da seção
                writer.Write(CByte(&H1))      ' número de tipos
                writer.Write(CByte(&H60))     ' tipo de função
                writer.Write(CByte(&H2))      ' número de parâmetros
                writer.Write(CByte(&H7F))     ' i32
                writer.Write(CByte(&H7F))     ' i32
                writer.Write(CByte(&H1))      ' número de retornos
                writer.Write(CByte(&H7F))     ' i32

                ' Seção de funções
                writer.Write(CByte(&H3))      ' id da seção: function
                writer.Write(CByte(&H2))      ' tamanho da seção
                writer.Write(CByte(&H1))      ' número de funções
                writer.Write(CByte(&H0))      ' índice do tipo

                ' Seção de exportações
                writer.Write(CByte(&H7))      ' id da seção: export
                writer.Write(CByte(&H7))      ' tamanho da seção
                writer.Write(CByte(&H1))      ' número de exportações
                writer.Write(CByte(&H3))      ' tamanho do nome "sum"
                writer.Write(Encoding.ASCII.GetBytes("sum"))
                writer.Write(CByte(&H0))      ' export kind: função
                writer.Write(CByte(&H0))      ' índice da função

                ' Seção de código
                writer.Write(CByte(&HA))      ' id da seção: code
                writer.Write(CByte(&H9))      ' tamanho da seção
                writer.Write(CByte(&H1))      ' número de funções
                writer.Write(CByte(&H7))      ' tamanho do corpo da função
                writer.Write(CByte(&H0))      ' declarações locais: 0

                ' Código da função: local.get 0, local.get 1, i32.add, end
                Dim code() As Byte = {&H20, &H0, &H20, &H1, &H6A, &HB}
                writer.Write(code)
            End Using
        End Using

        Console.WriteLine("Ficheiro main.wasm criado com sucesso!")
    End Sub
End Module
