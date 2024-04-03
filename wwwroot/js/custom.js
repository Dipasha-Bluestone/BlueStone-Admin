window.downloadAsPDF = function (tableId) {
    if (typeof jsPDF !== 'undefined') {
        const doc = new jsPDF();
        const table = document.getElementById(tableId);
        doc.autoTable({ html: table });

        // Save the PDF
        doc.save('table.pdf');
    } else {
        console.error('jsPDF is not defined. Make sure it is properly imported.');
    }
}

