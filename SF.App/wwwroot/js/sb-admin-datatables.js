// Call the dataTables jQuery plugin
$(document).ready(function() {
  $('#dataTable').DataTable({
    "language" : {
        "lengthMenu": "Wyświetl &nbsp; _MENU_ &nbsp; rekordów na stronie",
        "zeroRecords": "Brak rekordów",
        "info": "Strona &nbsp; _PAGE_ &nbsp; z &nbsp; _PAGES_",
        "infoEmpty": "Brak rekordów",
        "infoFiltered": "(filtered from _MAX_ total records)",
        "search" : "Wyszukaj:&nbsp;",
        paginate: {
          first:      "Pierwszy",
          previous:   "Poprzedni",
          next:       "Następny",
          last:       "Ostatni"
      },
    }
  });
});
