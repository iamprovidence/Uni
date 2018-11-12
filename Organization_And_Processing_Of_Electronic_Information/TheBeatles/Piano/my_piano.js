"use strict";

/* події для мишки
============================ */

$(".keyboard").mousedown(function(event){
  var note = "#" + event.target.id.slice(0, -4);
  playSingleNote($(note));
});

$(".keyboard").mouseup(function(event){
  var note = "#" + event.target.id.slice(0, -4);
  stopSingleNote($(note));
});


/* грати ноту
============================ */

function playSingleNote(note) {
  note.get(0).play();
}

/* зупинити ноту
============================ */

function stopSingleNote(note) {
    note.get(0).pause();
    note.get(0).currentTime = 0;
}
