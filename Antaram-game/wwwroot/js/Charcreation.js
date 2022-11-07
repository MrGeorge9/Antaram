$("#select1").change(function () {
    var race = $(this).val();

    $.ajax({
        type: 'GET',
        url: '/charcreation',
        success:
            function (response) {
                switch (race) {
                    case "human":
                        var markup = "<select name='Style'><option value='fighter'>Fighter</option><option value='mystic'>Mystic</option></select>";
                        var image = "<img src='../img/human-fighter.png'/>";
                        var charstats = "<ul><li>HP = 300</li><li>Mana = 100</li><li>Physical = 5</li><li>PhysicalDefense = 5</li><li>Magic = 1</li><li>MagicalDefense = 2</li></ul>"
                        break;
                    case "elf":
                        var markup = "<select name='Style'><option value='fighter'>Fighter</option><option value='mystic'>Mystic</option></select>";
                        var image = "<img src='../img/elven-fighter.png'/>";
                        var charstats = "<ul><li>HP = 250</li><li>Mana = 150</li><li>Physical = 7</li><li>PhysicalDefense = 3</li><li>Magic = 2</li><li>MagicalDefense = 1</li></ul>"
                        break;
                    case "dwarf":
                        var markup = "<select name='Style'><option value='fighter'>Fighter</option></select>";
                        var image = "<img src='../img/dwarven-fighter.png'/>";
                        var charstats = "<ul><li>HP = 450</li><li>Mana = 100</li><li>Physical = 3</li><li>PhysicalDefense = 8</li><li>Magic = 1</li><li>MagicalDefense = 4</li></ul>"
                        break;
                    case "orc":
                        var markup = "<select name='Style'><option value='fighter'>Fighter</option></select>";
                        var image = "<img src='../img/orc-fighter.png'/>";
                        var charstats = "<ul><li>HP = 350</li><li>Mana = 120</li><li>Physical = 10</li><li>PhysicalDefense = 2</li><li>Magic = 1</li><li>MagicalDefense = 2</li></ul>"
                }
                $("#select2").html("<label for='Style'>Style</label>" + markup);
                $("#image").html(image);
                $(".charstats").html(charstats);
            }
    });
})
$("#select2").change(function () {
    var style = $("#select2").val();
    var race = $("#select1").val();

    $.ajax({
        type: 'GET',
        url: '/charcreation',
        success:
            function (response) {
                if (race == "human") {
                    if (style == "fighter") {
                        var image = "<img src='../img/human-fighter.png'/>";
                        var charstats = "<ul><li>HP = 300</li><li>Mana = 100</li><li>Physical = 5</li><li>PhysicalDefense = 5</li><li>Magic = 1</li><li>MagicalDefense = 2</li></ul>"
                    }
                    else {
                        var image = "<img src='../img/human-mage.png'/>";
                        var charstats = "<ul><li>HP = 190</li><li>Mana = 300</li><li>Physical = 1</li><li>PhysicalDefense = 2</li><li>Magic = 5</li><li>MagicalDefense = 5</li></ul>"
                    }
                }
                else if (race == "elf") {
                    if (style == "fighter") {
                        var image = "<img src='../img/elven-fighter.png'/>";
                        var charstats = "<ul><li>HP = 250</li><li>Mana = 150</li><li>Physical = 7</li><li>PhysicalDefense = 3</li><li>Magic = 2</li><li>MagicalDefense = 1</li></ul>"
                    }
                    else {
                        var image = "<img src='../img/elven-mage.png'/>";
                        var charstats = "<ul><li>HP = 170</li><li>Mana = 350</li><li>Physical = 1</li><li>PhysicalDefense = 1</li><li>Magic = 7</li><li>MagicalDefense = 6</li></ul>"
                    }
                }
                $("#image").html(image);
                $(".charstats").html(charstats);
            }
    });
})