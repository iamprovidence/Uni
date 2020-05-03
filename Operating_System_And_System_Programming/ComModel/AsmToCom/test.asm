.model tiny 
.code
org 100h
start:  mov ah,9
    mov dx,offset Hello
    int 21h
    mov ah,0
    int 16h
    ret
Hello byte "Hello, world!$"
end start