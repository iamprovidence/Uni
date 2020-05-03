set /p filename=Write asm file name?: 
ml /Cp /AT %filename%.asm /link /T
del %filename%.obj