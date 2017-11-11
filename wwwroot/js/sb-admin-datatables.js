// Call the dataTables jQuery plugin
$(document).ready(function() {
  $('#dataTable').DataTable({
    "language" : {
        "lengthMenu": "Wyświetl _MENU_ rekordów na stronie",
        "zeroRecords": "Brak rekordów",
        "info": "Strona _PAGE_ z _PAGES_",
        "infoEmpty": "Brak rekordów",
        "infoFiltered": "(filtered from _MAX_ total records)",
        "search" : "Wyszukaj:",
        paginate: {
          first:      "Pierwszy",
          previous:   "Poprzedni",
          next:       "Następny",
          last:       "Ostatni"
      },
    }
  });
});
