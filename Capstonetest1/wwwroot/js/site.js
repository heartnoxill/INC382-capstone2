// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function mydate() {
    //alert("");
    document.getElementById("dt").hidden = false;
    document.getElementById("ndt").hidden = true;
  }
  
  function mydate1() {
    d = new Date(document.getElementById("dt").value);
    dt = d.getDate();
    mn = d.getMonth();
    mn++;
    yy = d.getFullYear();
    document.getElementById("ndt").value = dt + "/" + mn + "/" + yy
    document.getElementById("ndt").hidden = false;
    document.getElementById("dt").hidden = true;
  }