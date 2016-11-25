/*$('#cargarDetalle').click(function () {
    var pid = $(this).data('personid');
    var sid = $(this).data('surveyid');
    var url = '@Url.Action("SubmitSurvey", "Person")';
    $.post(url, { personid: pid, surveyid: sid }, function (data) {
        alert('updated');
    });
}); */

var url = '@Url.Action("FacturaDetalles", "Crear")';
$('#cargarDetalle').click(function () {
  
    $('#detalles').load(url, $this.data(ViewBag.FacId));
})