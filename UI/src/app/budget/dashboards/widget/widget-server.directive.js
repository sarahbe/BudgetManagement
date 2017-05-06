(function() {
    'use strict';

    angular
        .module('app.budget.dashboards')
        .directive('serverWidget', serverWidget);

    /* @ngInject */
    function serverWidget($timeout, $interval) {
        // Usage:
        //
        // Creates:
        //
        var directive = {
            require: 'triWidget',
            link: link,
            restrict: 'A'
        };
        return directive;

        function link($scope) {
            $scope.salesCharts = {
               
                data24hrs: {
                    series: ['Bandwidth'],
                    labels: ['00:00', '01:00', '02:00', '03:00', '04:00', '05:00', '06:00', '07:00', '08:00', '09:00', '10:00', '11:00', '12:00', '13:00', '14:00', '15:00', '16:00', '17:00', '18:00', '19:00', '20:00', '21:00', '22:00', '23:00'],
                    labelDatas: [0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24],

                    options: {
                        barShowStroke: false,
                        datasetFill: true,

                        maintainAspectRatio: false
                    }
                },
                data7days: {
                    series: ['Bandwidth'],
                   

                    options: {
                        barShowStroke: false,
                        datasetFill: true,

                        maintainAspectRatio: false
                    }
                },
                data365days: {
                    series: ['Bandwidth'],
              

                    options: {

                        barShowStroke: false,
                        datasetFill: true,

                        maintainAspectRatio: false
                    }
                }
            };

             

         
 
        }
    }
})();