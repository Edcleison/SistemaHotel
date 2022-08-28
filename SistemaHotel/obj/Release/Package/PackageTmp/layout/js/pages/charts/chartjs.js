

function getChartJs(type, val1, val2, val3, val4, val5, val6, val7, val8, val9, val10, val11, val12, val13, val14, val15, val16, val17, val18, val19, val20) {
    var config = null;

    if (type === 'line') {
        config = {
            type: 'line',
            data: {

                labels: ["Tx. Ocup.", "Tx. Vago", "Tx. Ind."],

                datasets: [{
                    label: "Santa Casa",
                    data: [val1, val2, val3],
                    borderColor: 'rgba(0, 188, 212, 0.75)',
                    backgroundColor: 'rgba(0, 188, 212, 0.3)',
                    pointBorderColor: 'rgba(0, 188, 212, 0)',
                    pointBackgroundColor: 'rgba(0, 188, 212, 0.9)',
                    pointBorderWidth: 1
                }, {
                    label: "Santa Isabel",
                    data: [val4, val5, val6],
                    borderColor: 'rgba(233, 30, 99, 0.75)',
                    backgroundColor: 'rgba(233, 30, 99, 0.3)',
                    pointBorderColor: 'rgba(233, 30, 99, 0)',
                    pointBackgroundColor: 'rgba(233, 30, 99, 0.9)',
                    pointBorderWidth: 1
                }]
            },
            options: {
                responsive: true,
                legend: true
            }
        }

    }
    else if (type === 'bar') {
        config = {
            type: 'bar',
            data: {
                labels: ["Ativo", "Extra", "Ocupacao", "Vago", "Alt.Med."],
                datasets: [{
                    label: "Santa Casa",
                    data: [val1, val2, val3, val4, val5],
                    backgroundColor: 'rgba(0, 188, 212, 0.8)'
                }, {
                    label: "Santa Isabel",
                    data: [val11, val12, val13, val14, val15],
                    backgroundColor: 'rgba(233, 30, 99, 0.8)'
                }]
            },
            options: {
                responsive: true,
                legend: true
            }
        }
    }
    else if (type === 'radar') {
        config = {
            type: 'radar',
            data: {
                labels: ["Indisp. Hc -" + val1 + " | Hsi -" + val5, "Manut. Hc -" + val2 + " | Hsi -" + val6, "Limpeza Hc -" + val3 + " | Hsi -" + val7, "Reser. Hc -" + val4 + " | Hsi -" + val8],
                datasets: [{
                    label: "Santa Casa",
                    data: [val1, val2, val3, val4],
                    borderColor: 'rgba(0, 188, 212, 0.8)',
                    backgroundColor: 'rgba(0, 188, 212, 0.5)',
                    pointBorderColor: 'rgba(0, 188, 212, 0)',
                    pointBackgroundColor: 'rgba(0, 188, 212, 0.8)',
                    pointBorderWidth: 1
                }, {
                    label: "Santa Isabel",
                    data: [val5, val6, val7, val8],
                    borderColor: 'rgba(233, 30, 99, 0.8)',
                    backgroundColor: 'rgba(233, 30, 99, 0.5)',
                    pointBorderColor: 'rgba(233, 30, 99, 0)',
                    pointBackgroundColor: 'rgba(233, 30, 99, 0.8)',
                    pointBorderWidth: 1
                }]
            },
            options: {
                responsive: true,
                legend: true
            }
        }
    }
    else if (type === 'pie') {
        config = {
            type: 'pie',
            data: {
                datasets: [{
                    data: [val1, val2],
                    backgroundColor: [
                        "rgb(0, 188, 212)",
                        "rgb(233, 30, 99)"
                    ],
                }],
                labels: [
                    "HC - Outros",
                    "HSI - Outros"
                ]
            },
            options: {
                responsive: true,
                legend: true
            }
        }
    }
    return config;
}

function getChartJs2(type, val1, val2, val3, val4, val5, val6, val7, val8, val9, val10, val11, val12, val13, val14, val15, val16, val17, val18, val19, val20) {
    var config = null;

    if (type === 'line') {
        config = {
            type: 'line',
            data: {

                labels: ["Indisp.", "Manut", "Limpeza", "Reser"],

                datasets: [{
                    label: "Santa Casa",
                    data: [val1, val2, val3, val4],
                    borderColor: 'rgba(0, 188, 212, 0.75)',
                    backgroundColor: 'rgba(0, 188, 212, 0.3)',
                    pointBorderColor: 'rgba(0, 188, 212, 0)',
                    pointBackgroundColor: 'rgba(0, 188, 212, 0.9)',
                    pointBorderWidth: 1
                }, {
                    label: "Santa Isabel",
                    data: [val5, val6, val7, val8],
                    borderColor: 'rgba(233, 30, 99, 0.75)',
                    backgroundColor: 'rgba(233, 30, 99, 0.3)',
                    pointBorderColor: 'rgba(233, 30, 99, 0)',
                    pointBackgroundColor: 'rgba(233, 30, 99, 0.9)',
                    pointBorderWidth: 1
                }]
            },
            options: {
                responsive: true,
                legend: true
            }
        }

    }
    else if (type === 'bar') {
        config = {
            type: 'bar',
            data: {
                labels: ["Outros Hc", "Outros Hsi"],
                datasets: [{
                    label: "Santa Casa",
                    data: [val1],
                    backgroundColor: 'rgba(0, 188, 212, 0.8)'
                }, {
                    label: "Santa Isabel",
                    data: [val2],
                    backgroundColor: 'rgba(233, 30, 99, 0.8)'
                }]
            },
            options: {
                responsive: true,
                legend: true
            }
        }
    }
    else if (type === 'radar') {
        config = {
            type: 'radar',
            data: {
                labels: ["Indisp. Hc -" + val1 + " | Hsi -" + val5, "Manut. Hc -" + val2 + " | Hsi -" + val6, "Limpeza Hc -" + val3 + " | Hsi -" + val7, "Reser. Hc -" + val4 + " | Hsi -" + val8],
                datasets: [{
                    label: "Santa Casa",
                    data: [val1, val2, val3, val4],
                    borderColor: 'rgba(0, 188, 212, 0.8)',
                    backgroundColor: 'rgba(0, 188, 212, 0.5)',
                    pointBorderColor: 'rgba(0, 188, 212, 0)',
                    pointBackgroundColor: 'rgba(0, 188, 212, 0.8)',
                    pointBorderWidth: 1
                }, {
                    label: "Santa Isabel",
                    data: [val5, val6, val7, val8],
                    borderColor: 'rgba(233, 30, 99, 0.8)',
                    backgroundColor: 'rgba(233, 30, 99, 0.5)',
                    pointBorderColor: 'rgba(233, 30, 99, 0)',
                    pointBackgroundColor: 'rgba(233, 30, 99, 0.8)',
                    pointBorderWidth: 1
                }]
            },
            options: {
                responsive: true,
                legend: true
            }
        }
    }
    else if (type === 'pie') {
        config = {
            type: 'pie',
            data: {
                datasets: [{
                    data: [val1, val2],
                    backgroundColor: [
                        "rgb(0, 188, 212)",
                        "rgb(233, 30, 99)"
                    ],
                }],
                labels: [
                    "HC - Outros",
                    "HSI - Outros"
                ]
            },
            options: {
                responsive: true,
                legend: true
            }
        }
    }
    return config;
}

function getChartJsHC(type, val1, val2, val3, val4, val5, val6, val7, val8, val9, val10) {
    var config = null;

    if (type === 'line') {
        config = {
            type: 'line',
            data: {
                labels: ["Indisp-" + val1, "Manut-" + val2, "Limp-" + val3, "Reser-" + val4,"Outros-" + val5],
                datasets: [{
                    label: "Santa Casa",
                    data: [val1, val2, val3, val4, val5],
                    borderColor: 'rgba(0, 188, 212, 0.8)',
                    backgroundColor: 'rgba(0, 188, 212, 0.5)',
                    pointBorderColor: 'rgba(0, 188, 212, 0)',
                    pointBackgroundColor: 'rgba(0, 188, 212, 0.8)',
                    pointBorderWidth: 1
                }]
            },
            options: {
                responsive: true,
                legend: true
            }
        }

    }
    else if (type === 'bar') {
        config = {
            type: 'bar',
            data: {
                labels: ["Ativo -" + val1, "Extra -" + val2, "Ocupacao -" + val3, "Vago -" + val4, "Alt.Med. -" + val5],
                datasets: [{
                    label: "Santa Casa",
                    data: [val1, val2, val3, val4, val5],
                    backgroundColor: 'rgba(0, 188, 212, 0.8)'
                }]
            },
            options: {
                responsive: true,
                legend: true
            }
        }
    }
    else if (type === 'radar') {
        config = {
            type: 'radar',
            data: {
                labels: ["Tx. Ocup. -" + val1, "Tx. Vago -" + val2, "Tx. Ind. -" + val3],

                datasets: [{
                    label: "Santa Casa",
                    data: [val1, val2, val3],
                    borderColor: 'rgba(0, 188, 212, 0.75)',
                    backgroundColor: 'rgba(0, 188, 212, 0.3)',
                    pointBorderColor: 'rgba(0, 188, 212, 0)',
                    pointBackgroundColor: 'rgba(0, 188, 212, 0.9)',
                    pointBorderWidth: 1
                }]
            },
            options: {
                responsive: true,
                legend: true
            }
        }
    }
    else if (type === 'pie') {
        config = {
            type: 'pie',
            data: {
                datasets: [{
                    data: [val1],
                    backgroundColor: [
                        "rgb(0, 188, 212)"
                    ],
                }],

                labels: [
                    "Outros"
                ]
            },
            options: {
                responsive: true,
                legend: true
            }
        }
    }
    return config;
}

function getChartJsHSI(type, val1, val2, val3, val4, val5, val6, val7, val8, val9, val10) {
    var config = null;

    if (type === 'line') {
        config = {
            type: 'line',
            data: {
                labels: ["Indisp-" + val1, "Manut-" + val2, "Limp-" + val3, "Reser-" + val4, "Outros-" + val5],
                datasets: [{
                    label: "Santa Isabel",
                    data: [val1, val2, val3, val4, val5],
                    borderColor: 'rgba(233, 30, 99, 0.75)',
                    backgroundColor: 'rgba(233, 30, 99, 0.3)',
                    pointBorderColor: 'rgba(233, 30, 99, 0)',
                    pointBackgroundColor: 'rgba(233, 30, 99, 0.9)',
                    pointBorderWidth: 1
                }]
            },
            options: {
                responsive: true,
                legend: true
            }
        }

    }
    else if (type === 'bar') {
        config = {
            type: 'bar',
            data: {
                labels: ["Ativo -" + val1, "Extra -" + val2, "Ocupacao -" + val3, "Vago -" + val4, "Alt.Med. -" + val5],
                datasets: [{
                    label: "Santa Isabel",
                    data: [val1, val2, val3, val4, val5],
                    backgroundColor: 'rgba(233, 30, 99, 0.8)'
                }]
            },
            options: {
                responsive: true,
                legend: true
            }
        }
    }
    else if (type === 'radar') {
        config = {
            type: 'radar',
            data: {
                labels: ["Tx. Ocup. -" + val1, "Tx. Vago -" + val2, "Tx. Ind. -" + val3],

                datasets: [{
                    label: "Santa Isabel",
                    data: [val1, val2, val3],
                    borderColor: 'rgba(233, 30, 99, 0.8)',
                    backgroundColor: 'rgba(233, 30, 99, 0.5)',
                    pointBorderColor: 'rgba(233, 30, 99, 0)',
                    pointBackgroundColor: 'rgba(233, 30, 99, 0.8)',
                    pointBorderWidth: 1
                }]
            },
            options: {
                responsive: true,
                legend: true
            }
        }
    }
    else if (type === 'pie') {
        config = {
            type: 'pie',
            data: {
                datasets: [{
                    data: [val1],
                    backgroundColor: [
                        "rgb(0, 188, 212)"
                    ],
                }],

                labels: [
                    "Outros"
                ]
            },
            options: {
                responsive: true,
                legend: true
            }
        }
    }
    return config;
}