using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class testSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Projects_ProjectId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_LikedComments_AspNetUsers_UserId",
                table: "LikedComments");

            migrationBuilder.DropForeignKey(
                name: "FK_LikedComments_Comments_CommentId",
                table: "LikedComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Images_ImageId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "DateUpdated", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 2, 0, "c5e605d7-f830-44e8-be30-9b5a88be6c15", new DateTime(2025, 1, 31, 17, 34, 0, 0, DateTimeKind.Local), new DateTime(2025, 1, 31, 17, 34, 0, 0, DateTimeKind.Local), "stilianmatev2@gmail.com", false, false, null, null, null, null, null, false, 6, null, false, "Other user 75" },
                    { 1006, 0, "4bddc102-82c5-48d4-b151-c5d1d7a2e081", new DateTime(2023, 1, 1, 2, 0, 0, 0, DateTimeKind.Local), new DateTime(2023, 1, 1, 2, 0, 0, 0, DateTimeKind.Local), "defaultuser@example.com", false, false, null, null, null, null, null, false, 2, null, false, "defaultuser" },
                    { 2002, 0, "f5ea7778-48ed-4e30-8a91-9fe5b26d6a50", new DateTime(2025, 3, 19, 12, 19, 42, 0, DateTimeKind.Local), new DateTime(2025, 3, 19, 12, 19, 42, 0, DateTimeKind.Local), "stilianmatev9@gmail.com", false, false, null, null, null, null, null, false, 1, null, false, "stilianmatev9@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "Path",
                value: "https://res.cloudinary.com/dgh3d67mh/image/upload/v1738515520/cld-sample-3.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "Path",
                value: "https://res.cloudinary.com/dgh3d67mh/image/upload/v1738515519/samples/dessert-on-a-plate.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "Path",
                value: "https://res.cloudinary.com/dgh3d67mh/image/upload/v1738515519/samples/woman-on-a-football-field.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "Path",
                value: "https://res.cloudinary.com/dgh3d67mh/image/upload/v1738515519/samples/cup-on-a-table.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "Path",
                value: "https://res.cloudinary.com/dgh3d67mh/image/upload/v1738515519/samples/coffee.jpg");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "Path",
                value: "https://res.cloudinary.com/dgh3d67mh/image/upload/v1738515517/samples/balloons.jpg");

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Path" },
                values: new object[,]
                {
                    { 7, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1738515518/samples/chair-and-coffee-table.jpg" },
                    { 8, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1738515518/samples/smile.jpg" },
                    { 9, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1738515518/samples/man-on-a-street.jpg" },
                    { 10, "https://res.cloudinary.com/demo/image/upload/cld-sample" },
                    { 11, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1738515520/cld-sample-5.jpg" },
                    { 14, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1738525813/dt8vuuiy2trsbscmtsha.png" },
                    { 15, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1738531565/ryg1hnxbkfnjay3ovlob.jpg" },
                    { 17, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1738531757/bktxumskbvupdwumonvi.jpg" },
                    { 18, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1738537102/szb1tfuyeyqjcousjbil.jpg" },
                    { 19, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1738569357/sttfj7u7gd52ncdcqs2n.jpg" },
                    { 20, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1738589084/afmssg32yuqmuyahoeuu.jpg" },
                    { 1001, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1739744914/ukerxix4yh11tcdbrlv3.jpg" },
                    { 1002, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1739745103/ggdaiqqbys37gvttek7t.jpg" },
                    { 1003, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1739745275/tveyp3qdj67qhdrzqvou.jpg" },
                    { 1004, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1739746977/rwe1tymwmfi6netiumqr.jpg" },
                    { 1005, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1739747130/nymt1atbhkbtablxsyph.jpg" },
                    { 1006, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1739750462/zcycb11mcnrners0q8io.jpg" },
                    { 1007, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1739752024/wol2f6movxx2zcplmpaj.jpg" },
                    { 1008, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1739752212/gs4a3h5r7yz7hzzvt2fz.jpg" },
                    { 1009, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1739796164/gbfwggqgosxknxlqxccf.png" },
                    { 1010, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1740845918/f3kbeubjwfqcsx59t93s.png" },
                    { 1011, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1740846040/glwtjsvogmldzterph8j.png" },
                    { 1012, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1740846069/mo7gtadwwrcynx7f7kwh.png" },
                    { 1013, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1740866488/jac1639pvqkhoezqipam.jpg" },
                    { 1014, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1740920264/qvadxplbktjq4knp3bto.png" },
                    { 1015, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1741055007/mczztpy8eryzx6w5wb6a.jpg" },
                    { 1016, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1741055593/m7xn4vijynr6nyl2dfag.jpg" },
                    { 1017, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1741055729/kj86lqe1p8nxl1jkoy30.jpg" },
                    { 2010, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1742251691/izasw5fok2pkg05feepu.jpg" },
                    { 2011, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1742303034/iibnkyxsoam4rafgfea2.jpg" },
                    { 2012, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1742394190/hovtnirq5tcuqgys5sht.jpg" },
                    { 2013, "https://api.dicebear.com/8.x/thumbs/svg?seed=stilianmatev06@gmail.com&flip=false&rotation=0&scale=90&radius=0&backgroundColor=ffcc00,ff6600,00cc99,3366ff,9900cc&backgroundType=solid,gradientLinear" },
                    { 3010, "https://api.dicebear.com/8.x/thumbs/svg?seed=stilianmatev0@gmail.com&flip=false&rotation=0&scale=90&radius=0&backgroundColor=ffcc00,ff6600,00cc99,3366ff,9900cc&backgroundType=solid,gradientLinear" },
                    { 3011, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1743511672/r8pfjuisxzpri3tsufne.jpg" },
                    { 3012, "https://api.dicebear.com/8.x/thumbs/svg?seed=stilianmatev00@gmail.com&flip=false&rotation=0&scale=90&radius=0&backgroundColor=ffcc00,ff6600,00cc99,3366ff,9900cc&backgroundType=solid,gradientLinear" },
                    { 3013, "https://api.dicebear.com/8.x/thumbs/svg?seed=stilianmatev000@gmail.com&flip=false&rotation=0&scale=90&radius=0&backgroundColor=ffcc00,ff6600,00cc99,3366ff,9900cc&backgroundType=solid,gradientLinear" },
                    { 3014, "https://api.dicebear.com/8.x/thumbs/svg?seed=stilianmatev@gmail000.com&flip=false&rotation=0&scale=90&radius=0&backgroundColor=ffcc00,ff6600,00cc99,3366ff,9900cc&backgroundType=solid,gradientLinear" },
                    { 3015, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1743597563/g936sby9xqquaoasvg6i.png" },
                    { 3016, "https://api.dicebear.com/8.x/thumbs/svg?seed=stilianmatev00@gmail.com&flip=false&rotation=0&scale=90&radius=0&backgroundColor=ffcc00,ff6600,00cc99,3366ff,9900cc&backgroundType=solid,gradientLinear" },
                    { 3017, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1743611953/gtg1mqvdwjgwrzzsgfpn.jpg" },
                    { 3018, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1743612162/swcd5ui4oqxq2u3ccvpa.jpg" },
                    { 3019, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1743612699/ck2cfuw6jhmjxvhomcdt.png" },
                    { 3020, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1743613036/l5yfi0b1rzgjmrazydtk.jpg" },
                    { 3021, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1743620862/qmoj4s3cknseaask7phj.jpg" },
                    { 3022, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1743620872/tjavtslw9sppmqhvrm3v.jpg" },
                    { 3023, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1743620878/xmemxjac9z5hyc0ieqch.jpg" },
                    { 3024, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1743620884/xwpcmepos5ijpvu5rkx9.jpg" },
                    { 3025, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1743620891/ync6fn3selghocejltsi.jpg" },
                    { 3026, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1743621293/fzirdojil76nz7kz1cuq.jpg" },
                    { 3027, "https://res.cloudinary.com/dgh3d67mh/image/upload/v1743630577/vrgzp0j0dl8csct2futk.png" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "DateUpdated", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "10528436-e61f-4c72-b228-104e9b1c3bea", new DateTime(2025, 1, 31, 1, 25, 46, 0, DateTimeKind.Local), new DateTime(2025, 1, 31, 1, 25, 46, 0, DateTimeKind.Local), "stilianmatev@gmail.com", false, false, null, null, null, null, null, false, 2012, null, false, "Steli" },
                    { 2003, 0, "4a865c8b-a6d6-446b-a3c3-705af90eee00", new DateTime(2025, 3, 19, 17, 14, 14, 0, DateTimeKind.Local), new DateTime(2025, 3, 19, 17, 14, 14, 0, DateTimeKind.Local), "stilianmatev06@gmail.com", false, false, null, null, null, null, null, false, 2013, null, false, "stilianmatev06@gmail.com" },
                    { 3002, 0, "f28e7db9-df3f-4801-b7e7-dd0a2e023d9d", new DateTime(2025, 4, 1, 15, 9, 5, 0, DateTimeKind.Local), new DateTime(2025, 4, 1, 15, 9, 5, 0, DateTimeKind.Local), "stilianmatev0@gmail.com", false, false, null, null, null, null, null, false, 3010, null, false, "stilianmatev0@gmail.com" },
                    { 3003, 0, "9dda870c-df1d-4c05-b4e7-dc6161ff6ebe", new DateTime(2025, 4, 2, 14, 43, 53, 0, DateTimeKind.Local), new DateTime(2025, 4, 2, 14, 43, 53, 0, DateTimeKind.Local), "stilianmatev00@gmail.com", false, false, null, null, null, null, null, false, 3015, null, false, "stilianmatev00" },
                    { 3004, 0, "ecc1e814-accd-497b-903e-10c52c7102d8", new DateTime(2025, 4, 2, 15, 0, 39, 0, DateTimeKind.Local), new DateTime(2025, 4, 2, 15, 0, 39, 0, DateTimeKind.Local), "stilianmatev000@gmail.com", false, false, null, null, null, null, null, false, 3013, null, false, "stilianmatev000@gmail.com" },
                    { 3005, 0, "324c0c8e-b9a7-4f7f-ba3d-7b392c8aa70f", new DateTime(2025, 4, 2, 15, 1, 35, 0, DateTimeKind.Local), new DateTime(2025, 4, 2, 15, 1, 35, 0, DateTimeKind.Local), "stilianmatev@gmail000.com", false, false, null, null, null, null, null, false, 3014, null, false, "stilianmatev@gmail000.com" },
                    { 3006, 0, "6e47c645-96ff-4e80-8192-31ff722b1c50", new DateTime(2025, 4, 2, 16, 2, 32, 0, DateTimeKind.Local), new DateTime(2025, 4, 2, 16, 2, 32, 0, DateTimeKind.Local), "stilianmatev00@gmail.com", false, false, null, null, null, null, null, false, 3016, null, false, "stilianmatev00@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CategoryId", "Description", "ImageId", "ShortDescription", "Title", "UserId" },
                values: new object[,]
                {
                    { 3, 1, "<h1><strong>Здравейте : D</strong></h1><p><br></p><h2>тук ще разкажа за всички инструменти, които съм ползвал за да направя сайта : )</h2><p><br></p><h2><strong>Как направих сайта?</strong></h2><p>Логическите операции и цялата задна част на сайта (back-end) съм разработил с .NET 8 и Entity Framework Core – ORM framework за езика за програмиране C#.</p><p>Използвах Code First подход за работа с Microsoft SQL Server. </p><p><strong>C#</strong> е създаден от <strong>Microsoft </strong>и се използва широко за разработка на бекенд логика на уебсайтове, десктоп и мобилни приложения, както и в сферата на игрите и облачните технологии.</p><p><br></p><p>Структурата на сайта е разделена на 3 основни части - Модели(Model), Изгледи(View) и Контролери(Controller), или така нареченият <strong>MVC</strong> модел на разработка на бекенд за уебсайтове</p><h3><br></h3><p>За уеб страниците използвах <strong>Razor</strong> – синтаксис на ASP.NET Core, който позволява вграждане на<strong> C#</strong> код в <strong>HTML</strong>. </p><p>Той се използва за създаване на интерактивни и динамични уеб страници в комбинация с <strong>MVC</strong> (Model-View-Controller) или <strong>Razor Pages</strong>.</p><p><br></p><p>Използвал съм и <strong>JavaScript </strong>– скриптов език, който позволява уеб страниците да бъдат динамични и интерактивни, като добавя функционалности, изпълнявани от страна на клиента (client-side)</p><p><br></p><p>Също така съм използвал <strong>CSS</strong> – езикът, който се използва за стилизиране на уеб страниците, като определя техния външен вид, оформление и адаптивност.</p><p><br></p><p>Използвах <strong>SQL</strong> за работа с базата данни в <strong>Microsoft SQL Server </strong>– релационна система за управление на бази данни, в която информацията се съхранява в таблици и се обработва чрез заявки на <strong>SQL</strong></p><h3><br></h3><h3><strong>Първоначална профилна снимка</strong></h3><ul><li>За първоначалната профилна снимка използвах <a href=\"https://www.dicebear.com/\" target=\"_blank\">Dice bear</a> — сайт, </li></ul><p> който ти позволява да създаваш профилни картинки с помоща на първоначален seed</p><p> за seed използвах вашият имейл, защото така усигорявах уникалност на всяка иконка</p><p> това е линка към иконката ви : )</p><p> просто сложете имейл адреса си на определеното място и ще видите иконката си</p><p> или може да сложите какъвто и да е друг текст за друга иконка : )</p><p><br></p><p><strong>https://api.dicebear.com/8.x/thumbs/svg?seed=&lt;вашият имейл адрес&gt;&amp;flip=false&amp;rotation=0&amp;scale=90&amp;radius=0&amp;backgroundColor=ffcc00,ff6600,00cc99,3366ff,9900cc&amp;backgroundType=solid,gradientLinear</strong></p><p><br></p><h3><strong>Съхранение на снимки</strong></h3><p>За съгранение на всички останали снимки аз използвам <a href=\"https://cloudinary.com/\" target=\"_blank\">Cloudinary</a></p><p> — това е програма, която ти позволява да съхраняваш снимки, видеа и гифчета</p><p> използвах я, защото беше лесна за използване и  безплатният план ми стига за сега : )</p><h3><br></h3><h3>накратко:</h3><h3>Използвах <strong>C#</strong> за език за програмиране на back-end логиката на сайта с <strong>MVC </strong></h3><h3>модел на структурата на приложението, </h3><h3><strong>Entity Framework Core</strong> за Framework на сайта,</h3><h3><strong>Razor Pages</strong> за страниците</h3><h3><strong>Javascript </strong>за динамични и интерактивни уеб страници, </h3><h3><strong>CSS </strong>за стилизиране на уеб страници,</h3><h3><strong>SQL </strong>за структорирана база данни,</h3><h3><a href=\"https://cloudinary.com/\" target=\"_blank\"><strong>Cloudinary</strong></a> за Съхраняване на всички снимки от сайта и</h3><h3><a href=\"https://www.dicebear.com/\" target=\"_blank\"><strong>Dice bear</strong></a> за първоначални профилни снимки</h3><p><br></p><h3><br></h3><p><br></p>", 1009, "това е този проекта за сайта, в който сте ; )", "Портфолио проект : )", 1 },
                    { 5, 3, "<p>Този робот бе направен от мен и моите приятели за състезанието Роботика за Бъгария и спечели шампионската купа : )</p><p><br></p><p>Ние използвахме Ардуино Уно(Arduino Uno) за конмютър за роботчето</p><p>&lt;img style=\"width:200px;\" src=\"https://res.cloudinary.com/dgh3d67mh/image/upload/v1743611953/gtg1mqvdwjgwrzzsgfpn.jpg\" alt = \"снимка на платката Ардуино Уно\"&gt; </p><p>това е снимка, която показва как изглеждаше платката</p><p>линк за закупуване на платката:</p><p><a href=\"https://www.electronicevolution.bg/bg-product-details-14.html\" target=\"_blank\">https://www.electronicevolution.bg/bg-product-details-14.html</a></p><p><br></p><p>за да подкараме роботчето да се движи използвахме драйевера L298N motor driver</p><p>&lt;img style=\"width:200px;\" src=\"https://res.cloudinary.com/dgh3d67mh/image/upload/v1743612162/swcd5ui4oqxq2u3ccvpa.jpg\" alt=\"снимка на драйвера L298N\"&gt;</p><p>линк към драйвера:</p><p><a href=\"https://www.electronicevolution.bg/bg-product-details-91.html\" target=\"_blank\">https://www.electronicevolution.bg/bg-product-details-91.html</a></p><p><br></p><p>използвахме едни жълти мотори за ардуино, защото те бяха точни и силни</p><p>&lt;img style=\"width:200px;\" src = \"https://res.cloudinary.com/dgh3d67mh/image/upload/v1743612699/ck2cfuw6jhmjxvhomcdt.png\" alt = \"моторите, които използвахме\"&gt;</p><p>линк: </p><p><a href=\"https://elimex.bg/product/79622-kit-k2178-postoyannotokov-motor-za-robo-platforma\" target=\"_blank\">https://elimex.bg/product/79622-kit-k2178-postoyannotokov-motor-za-robo-platforma</a></p><p><br></p><p>Синьото моторче отгоре на роботчето е серво моторче</p><p>то е по-слабо, но е много точно и бързо и се излпозлва за точни движения</p><p>ние го използвахме като ръка на роботчето, като му закачихме маркер замотора</p><p>&lt;img style=\"width:200px;\" src=\"https://res.cloudinary.com/dgh3d67mh/image/upload/v1743613036/l5yfi0b1rzgjmrazydtk.jpg\" alt=\"снимка на моторчето\"&gt;</p><p>линк:</p><p><a href=\"https://elimex.bg/product/87587-df9gms-360-mikro-servo-motor-ser0043\" target=\"_blank\">https://elimex.bg/product/87587-df9gms-360-mikro-servo-motor-ser0043</a></p><p><br></p><p>Тялото го моделирахме заедно с мой приятел в <a href=\"https://www.autodesk.com/products/fusion-360/personal#top\" target=\"_blank\">Fusion 360</a> – професионален софтуер за 3D моделиране и инженерно проектиране, </p><p>който предлага задълбочени инструменти за дизайн, симулация и производство.</p><p>притирахме го в зелена пласмата на моят 3D принтер <a href=\"https://www.creality.com/products/creality-k1-max-3d-printer\" target=\"_blank\">Creality K1 Max</a></p><p><br></p><p>очичките ги взехме от книжарница и бяха супер добавка, към вече супер сладкото роботче : )</p><p><br></p>", 1003, "Това е робота, с който спечелихме Роботика за България 2024", "Робот за Роботика за България", 1 },
                    { 1002, 2, "<p>Вдъхновението за създаването на този модел на монета, дойде, когато играх Dungeons &amp; Dragons с брат ми.  За тези, които не знаят, Dungeons &amp; Dragons(D&amp;D)  ролева игра, в която има играч, който е разказвача, и играчи, които играят.  Аз играех като разказвача тогава, а брат ми беше играча. Беше станало на въпрос, че нямаме игрални монети, които да му дам, като намери съкровище.   Тогава реших да пробвам да намеря някави монети и да си направя някоя custom монета.  В момента на писане на този проект монетите, които бях принтирал не са при мен</p><p><br></p><p>Монетата е моделирана в програмата <a href=\"https://www.shapr3d.com/\" target=\"_blank\">Shapr3D</a> - програма за 3D моделиране, подобна на <a href=\"https://www.autodesk.com/products/fusion-360/personal#top\" target=\"_blank\">Fussion 360</a>, но много по-лесна за използване</p><p>тя не е толкова голяма колкото <a href=\"https://www.autodesk.com/products/fusion-360/personal#top\" target=\"_blank\">Fussion 360</a>, като и липсват аспектите за симулация и производство, които Fussion 360 има, </p><p>но за сметка на това е много по-интуитивна и лесна за използване  </p><p>  ресурси:  <a href=\"https://www.printables.com/model/331064-dnd-coins\">монетите, които бях намерил</a>      Моята монета:  <a href=\" https://www.printables.com/model/1213516-dd-elven-coin\">Моята монета</a>      </p>", 1014, "това е custom D&D монета, която направих преди", "custom D&D монета :)", 1 },
                    { 2002, 4, "<style>      :root {        --columns: 2; /* Брой колони в галерията по подразбиране */        --overlay-opacity: 0.8; /* Степен на затъмнение на фона при lightbox */        --transition-duration: 0.3s; /* Продължителност на анимациите */        --border-radius: 10px; /* Радиус за заобляне на ъглите */      }            /* Галерия */      #gallery {        display: grid;        grid-template-columns: repeat(var(--columns), 1fr);        grid-gap: 15px;              }            .gallery-item {        position: relative;        overflow: hidden;        cursor: pointer;        border-radius: var(--border-radius);      }            .gallery-item img {        width: 100%;        height: auto;        display: block;        border-radius: var(--border-radius);        transition: transform var(--transition-duration) ease;      }            .gallery-item .caption {        position: absolute;        bottom: -100%;        left: 0;        width: 100%;        background: rgba(255, 255, 255, 0.8);        color: #000;        padding: 10px;        box-sizing: border-box;        transition: transform var(--transition-duration) ease, opacity var(--transition-duration) ease;        text-align: center;        font-size: 14px;      }            .gallery-item:hover img {        transform: translateY(-10px) scale(1.05);      }            .gallery-item:hover .caption {        transform: translateY(-100%);        opacity: 1;      }            /* Lightbox */      #lightbox-overlay {        position: fixed;        top: 0;        left: 0;        width: 100%;        height: 100%;        background: rgba(0, 0, 0, var(--overlay-opacity));        display: flex;        align-items: center;        justify-content: center;        opacity: 0;        pointer-events: none;        transition: opacity var(--transition-duration) ease;        z-index: 1000;      }            #lightbox-overlay.active {        opacity: 1;        pointer-events: auto;      }            #lightbox-content {        border-radius: 10px;          position: relative;        background: black; /* Черно осветление за съдържанието */        padding: 20px;        box-sizing: border-box;        max-width: 90%;        max-height: 90%;        overflow: hidden;        text-align: center;        animation: scaleIn var(--transition-duration) ease;      }            @keyframes scaleIn {        from { transform: scale(0.8); }        to { transform: scale(1); }      }            #lightbox-content img {        max-width: 100%;        max-height: calc(90vh - 60px); /* За да се побере и текстът/бутоните */        width: auto;        height: auto;        margin-bottom: 10px;        border-radius: var(--border-radius);      }            #lightbox-close {        border-radius: 40px;        position: absolute;        top: 10px;        right: 10px;        background: #333;        color: white;        border: none;        font-size: 18px;        padding: 5px 10px;        cursor: pointer;        transition: background var(--transition-duration) ease;      }            #lightbox-close:hover {        background: #555;      }            #lightbox-caption {        color: white;        font-size: 16px;      }      </style>            <!-- Контейнер за галерията -->      <div id=\"gallery\"></div>            <!-- Lightbox -->      <div id=\"lightbox-overlay\">        <div id=\"lightbox-content\">          <button id=\"lightbox-close\">&times;</button>          <img src=\"\" alt=\"Enlarged Image\">          <div id=\"lightbox-caption\"></div>        </div>      </div>            <script>      document.addEventListener(\"DOMContentLoaded\", function() {        // Примерен двумерен масив с 6 изображения: [URL на снимката, текст към снимката]        var galleryData = [          [\"https://res.cloudinary.com/dgh3d67mh/image/upload/v1743620862/qmoj4s3cknseaask7phj.jpg\", \"Пътеката на язовира\", \"https://res.cloudinary.com/dgh3d67mh/image/upload/v1743620862/qmoj4s3cknseaask7phj.jpg\"],          [\"https://res.cloudinary.com/dgh3d67mh/image/upload/v1743620872/tjavtslw9sppmqhvrm3v.jpg\", \"Растеше между камъните и беше много красиво\", \"https://res.cloudinary.com/dgh3d67mh/image/upload/v1743620872/tjavtslw9sppmqhvrm3v.jpg\"],          [\"https://res.cloudinary.com/dgh3d67mh/image/upload/v1743620878/xmemxjac9z5hyc0ieqch.jpg\", \"Облаците тук станаха доста хубави\", \"https://res.cloudinary.com/dgh3d67mh/image/upload/v1743620878/xmemxjac9z5hyc0ieqch.jpg\"],          [\"https://res.cloudinary.com/dgh3d67mh/image/upload/v1739746977/rwe1tymwmfi6netiumqr.jpg\", \"Нивото на водата беше под 12% и беше станало много красиво\", \"https://res.cloudinary.com/dgh3d67mh/image/upload/v1739746977/rwe1tymwmfi6netiumqr.jpg\"],          [\"https://res.cloudinary.com/dgh3d67mh/image/upload/v1742251691/izasw5fok2pkg05feepu.jpg\", \"Отражението на облиците е много красиво\", \"https://res.cloudinary.com/dgh3d67mh/image/upload/v1742251691/izasw5fok2pkg05feepu.jpg\"],          [\"https://res.cloudinary.com/dgh3d67mh/image/upload/v1743620891/ync6fn3selghocejltsi.jpg\", \"Тази снимка е много хубава според мен и може да е като wallpaper\", \"https://res.cloudinary.com/dgh3d67mh/image/upload/v1743620891/ync6fn3selghocejltsi.jpg\"],          [\"https://res.cloudinary.com/dgh3d67mh/image/upload/v1743620884/xwpcmepos5ijpvu5rkx9.jpg\", \"Облаците на тази снимка станаха много хубави според мен\", \"https://res.cloudinary.com/dgh3d67mh/image/upload/v1743620884/xwpcmepos5ijpvu5rkx9.jpg\"],        ];              var galleryContainer = document.getElementById(\"gallery\");              // Функция за създаване на елемент за всяка снимка        function createGalleryItem(imageSrc, captionText) {          var item = document.createElement(\"div\");          item.className = \"gallery-item\";                // Създаваме линк, който обгръща изображението          var link = document.createElement(\"a\");          link.href = imageSrc; // Може да отваря снимката в нов таб ако е нужно          link.target = \"_blank\";                var img = document.createElement(\"img\");          img.src = imageSrc;          img.alt = captionText;          link.appendChild(img);          item.appendChild(link);                // Създаваме елемент за коментара          var caption = document.createElement(\"div\");          caption.className = \"caption\";          caption.textContent = captionText;          item.appendChild(caption);                // При клик – отваряме lightbox          item.addEventListener(\"click\", function(e) {            e.preventDefault();            openLightbox(imageSrc, captionText);          });                return item;        }              // Попълване на галерията        galleryData.forEach(function(data) {          var galleryItem = createGalleryItem(data[0], data[1]);          galleryContainer.appendChild(galleryItem);        });              // Lightbox функционалност        var lightboxOverlay = document.getElementById(\"lightbox-overlay\");        var lightboxContent = document.getElementById(\"lightbox-content\");        var lightboxImage = lightboxContent.querySelector(\"img\");        var lightboxCaption = document.getElementById(\"lightbox-caption\");        var lightboxClose = document.getElementById(\"lightbox-close\");              function openLightbox(imageSrc, captionText) {          lightboxImage.src = imageSrc;          lightboxCaption.textContent = captionText;          lightboxOverlay.classList.add(\"active\");        }              function closeLightbox() {          lightboxOverlay.classList.remove(\"active\");        }              lightboxClose.addEventListener(\"click\", function(e) {          e.stopPropagation();          closeLightbox();        });              lightboxOverlay.addEventListener(\"click\", function(e) {          if(e.target === lightboxOverlay) {            closeLightbox();          }        });      });      </script>      ", 3026, "Това е галерия с няколко снимки, които бях направил като годих да снимам на язовир Копринка с един приятел", "Снимки, които направих на Язовир Копринка", 1 },
                    { 2003, 1, "<h1>Какво са Multi Agent Systems(<strong>MAS</strong>)?</h1><h3>Multi Agent Systems(<strong>MAS</strong>), или на по просто казано, екип от ИИ, които работят в екип за да постигнат дадена задача</h3><h3>в такива системи отделните ИИ (от сега нататък в поста ще ги наричам модели) ще изпълняват различни подзадачи на главната задача.</h3><p><br></p><ul><li>Например, ако искаме да направим <strong>MAS, </strong>който да направи пост за блог, може да имаме система от 3 модела - </li><li class=\"ql-indent-1\">един, който се занимава само с проучване по темата и събиране на информация</li><li class=\"ql-indent-1\">втори, който да пише самият пост, като използва събраната за поста информация от предишният модел, или по-правилият термин е агент</li><li class=\"ql-indent-1\">Третият модел (агент) ще изпълнява ролята на проверяващ – той ще оцени дали постът е добре структуриран,</li></ul><p>      дали материалът е използван правилно и ще извърши допълнителни проверки, преди да го финализира и върне на потребителя, който е стартирал процеса.</p><p><br></p><ul><li> По този начин получаваме много по-добри резултати, отколкото ако разчитаме само на ChatGPT. Когато той трябва да изпълнява всички задачи самостоятелно, </li></ul><h3>    качеството може да пострада, тъй като ресурсите му се разпределят между множество задачи, вместо да се фокусира върху една с максимална прецизност.</h3><h3> </h3><p>&lt;br&gt;</p><ul><li> Друго голямо предимство, е че когато отделни модели правят различни задачи, ние можем да сложим различни изкуствени интелекти да вършат </li></ul><h3>различни задачи. </h3><p><br></p><ul><li> Например, ако погледнем горният пример, можем на агента, който пише поста да му сложим <a href=\"https://groq.com/\" target=\"_blank\">Groq</a>, защото, той е много по-добър в писане на текстове, от колкото ChatGPT, който е много добър за проучване на информация и Claude за проверяване на блога след това, защото той е много по-добър в това от другите два модела : D</li></ul><p><br></p><h1>Какво съм направил аз?</h1><h2> Аз направих репозитори в GitHub, В което съм качил вече 10 проекта и още десет, които скоро ще се направят : )</h2><h2> </h2><h2><strong> </strong><a href=\"https://github.com/OneDuckyBoy/Awesome-AI-Agents-HUB-for-CrewAI\" target=\"_blank\"><strong>Линк към Repository-то ми</strong></a></h2><h2><br></h2><h2> Списък с проектите, които съм направил досега : D</h2><ul><li><a href=\"https://github.com/OneDuckyBoy/awesome-CrewAI-projects/tree/main/marketing_posts_crew\" target=\"_blank\" style=\"color: rgb(0, 123, 255);\">💼&nbsp;Маркетинг агенти&nbsp;– Автоматино правене на постове за Социални медии и Имейл маркетинг и поща</a></li><li class=\"ql-indent-1\">Използвай изкуствен интелект, за да създаваш завладяващи публикации за Facebook, Instagram, X.com, Threads и други.</li><li><a href=\"https://github.com/OneDuckyBoy/awesome-CrewAI-projects/tree/main/test_maker_crew\" target=\"_blank\" style=\"color: rgb(0, 123, 255);\">📝&nbsp;</a><a href=\"https://github.com/OneDuckyBoy/awesome-CrewAI-projects/tree/main/test_maker_crew\" target=\"_blank\">Test Maker Crew – Динамично генериране на тестове</a></li><li class=\"ql-indent-1\">Генерирайте задълбочени и изчерпателни тестове по всяка тема.</li><li><a href=\"https://github.com/OneDuckyBoy/awesome-CrewAI-projects/tree/main/health_and_fittness_planner\" target=\"_blank\" style=\"color: rgb(0, 123, 255);\">🏋️</a><a href=\"https://github.com/OneDuckyBoy/awesome-CrewAI-projects/tree/main/health_and_fittness_planner\" target=\"_blank\">Екип за здраве и фитнес планове</a></li><li class=\"ql-indent-1\">Изграждайте персонализирани здравни и фитнес програми с помощта на усъвършенствани AI анализи</li><li><a href=\"https://github.com/OneDuckyBoy/awesome-CrewAI-projects/tree/main/movie_recommendation_crew\" target=\"_blank\" style=\"color: rgb(0, 123, 255);\">🍿&nbsp;</a><a href=\"https://github.com/OneDuckyBoy/awesome-CrewAI-projects/tree/main/movie_recommendation_crew\" target=\"_blank\">Екип за препоръки на филми и сериали</a></li><li class=\"ql-indent-1\">Получавайте персонализирани предложения за филми и телевизионни предавания.</li><li><a href=\"https://github.com/OneDuckyBoy/awesome-CrewAI-projects/tree/main/subject_teaching_crew\" target=\"_blank\" style=\"color: rgb(0, 123, 255);\">📚&nbsp;</a><a href=\"https://github.com/OneDuckyBoy/awesome-CrewAI-projects/tree/main/subject_teaching_crew\" target=\"_blank\">Екип за подготовка на учебни материали</a></li><li class=\"ql-indent-1\">Създавайте висококачествени учебни ресурси и ръководства за обучение.</li><li><a href=\"https://github.com/OneDuckyBoy/awesome-CrewAI-projects/tree/main/journalist_crew\" target=\"_blank\" style=\"color: rgb(0, 123, 255);\">📰&nbsp;</a><a href=\"https://github.com/OneDuckyBoy/awesome-CrewAI-projects/tree/main/journalist_crew\" target=\"_blank\">Екип за журналистика</a></li><li class=\"ql-indent-1\">Пишете подробни и висококачествени статии с помощта на AI.</li><li><a href=\"https://github.com/OneDuckyBoy/Awesome-AI-Agents-HUB-for-CrewAI/tree/main/competitor_analys_crew\" target=\"_blank\" style=\"color: rgb(0, 123, 255);\">🏆&nbsp;</a><a href=\"https://github.com/OneDuckyBoy/Awesome-AI-Agents-HUB-for-CrewAI/tree/main/competitor_analys_crew\" target=\"_blank\">Екип за анализ на конкуренцията</a></li><li class=\"ql-indent-1\">Проучвайте стратегиите на конкурентите и получавайте изчерпателни доклади.</li><li><a href=\"https://github.com/OneDuckyBoy/Awesome-AI-Agents-HUB-for-CrewAI/tree/main/investment_stock_analys_crew\" target=\"_blank\" style=\"color: rgb(0, 123, 255);\">📈&nbsp;</a><a href=\"https://github.com/OneDuckyBoy/Awesome-AI-Agents-HUB-for-CrewAI/tree/main/investment_stock_analys_crew\" target=\"_blank\">Екип за анализ на инвестиции и акции</a></li><li class=\"ql-indent-1\">Вземайте информирани инвестиционни решения с AI-генерирани анализи.</li><li><a href=\"https://github.com/OneDuckyBoy/Awesome-AI-Agents-HUB-for-CrewAI/tree/main/finance_agent_crew\" target=\"_blank\" style=\"color: rgb(0, 123, 255);\">💰&nbsp;</a><a href=\"https://github.com/OneDuckyBoy/Awesome-AI-Agents-HUB-for-CrewAI/tree/main/finance_agent_crew\" target=\"_blank\">Екип за финансови консултации</a></li><li class=\"ql-indent-1\">Оптимизирайте финансовите си планове и откривайте нови възможности.</li><li><a href=\"https://github.com/OneDuckyBoy/Awesome-AI-Agents-HUB-for-CrewAI/tree/main/lawyer_agent_crew\" target=\"_blank\">⚖️ <strong>Екип за правни консултации</strong></a></li><li class=\"ql-indent-1\">Предоставя AI-генерирани правни становища и препоръчани стъпки.</li></ul><p><br></p><h2>Как са направени тези проекти?</h2><p> Тези проекти са направени с помощта на framework-a <a href=\"https://www.crewai.com/\" target=\"_blank\">Crew AI</a></p><p> този framework прави създаването и използването на <a href=\"https://bg.wikipedia.org/wiki/%D0%A1%D0%BE%D1%84%D1%82%D1%83%D0%B5%D1%80%D0%B5%D0%BD_%D0%B0%D0%B3%D0%B5%D0%BD%D1%82\" target=\"_blank\"><strong>MAS</strong></a><strong> </strong>(бг Уикипедия страницата не е направена още - ще я направя скоро</p><p>и ще заменя линка с правилната страница)</p><h2>Какво представляват тези агенти?</h2><h3> Агентите в Crew AI са обекти, които използват даден Модел на ИИ и му дават настройките, които сте задали в агента</h3><ul><li>Структурата на един агент в общия случай е: </li><li class=\"ql-indent-1\">име на агента - име по което другите агенти се ориентират към кой да се обърнат, като работят помежду си</li><li class=\"ql-indent-1\">Цел на агента - Какво искаме агента да постигне - да намери информация в интернет на дадена тема, или да напише добър блог пост</li><li class=\"ql-indent-1\">Предистория - ИИ работят по-добре, когато влязат в роля - например първият агент от по-горният пример ще е учен, </li></ul><p>         който се е специализирал в намирането на най-подходящaта информация на дадена тема</p><ul><li class=\"ql-indent-1\">модел - кой ИИ ще използваме за дадената задача?</li><li class=\"ql-indent-1\">Може ли да предава задачи - дали може ли да дава задачи на други агенти, ако прецени, че те ще се справят по-добре с дадената задача</li><li class=\"ql-indent-1\">разговорлив(verbose) - дебъг функция, в която агента ще изписва всичко, което прави в конзолата - ако искаме да проверим какво прави, </li></ul><p class=\"ql-indent-2\">или ако ни е интересно как стават нещата, това се пуска</p><ul><li class=\"ql-indent-1\">Инструменти - това са специални класове, които позволяват на Агента да прави различни задачи, които не са точно писане на текстове, а например:</li><li class=\"ql-indent-2\">търсене в интернет</li><li class=\"ql-indent-2\">правене на pdf файлове</li><li class=\"ql-indent-2\">четене от файлове</li><li class=\"ql-indent-2\">генериране на снимки</li></ul><p><br></p><h2>Как изпълняват задачи тези агенти?</h2><h3> Агентите имат задачи, които трябва да правят, както ние като отидем на работа вършим някакви задачи, така и Агентите си имат техни задачи за правене</h3><ul><li>Структура на една задача в общия случай</li><li class=\"ql-indent-1\">Описание на задачата - описание на задачата, която трябва да се направи, написана на английски</li><li class=\"ql-indent-1\">Очакван резултат - какво очаквме да получим при направена задача</li><li class=\"ql-indent-1\">Агент, който да изпълни задачата - агента, който сме направили за тази задача - един агент може да прави няколко задачи</li><li class=\"ql-indent-1\">Задачи, които чака да свършат - може да се направи, така че една задача да се налага да чака друга задача да свърши, за да може тя да си изпълни своята</li><li class=\"ql-indent-1\">разговорлив(verbose)  - същото като при агента</li><li class=\"ql-indent-1\">Инструменти - Същото като при инстументите, но агентите имат достъп до тях само когато правят определена задача</li></ul><h2>Какъв тип Екипи има?</h2><ul><li>Има два типа екипи</li><li class=\"ql-indent-1\">пореден - Има начален агент и той като свърши дава каквото е направил на следващият агент и така до края</li><li class=\"ql-indent-1\">Йерархичен - Има един агент, който е отговорник на екипа - той обикновено използва по-силен модел, защото той разпределя задачите, оценява дали са изпълнени добре</li></ul><p>       и дали да продулжи със следващата задача, или да накара агента да направи задачата пак, като му даде насоки как да я направи правилно</p><p> </p>", 3027, "В този проект ще ви разкажа малко за проектите, които разработих с Multi Agent System framework-а Crew AI", "Multi Agent Systems(MAS) - Екип от ИИ е по-добър от един ", 1 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "DateAdded", "ImageId", "ProjectId", "Text", "UserId" },
                values: new object[,]
                {
                    { 3, new DateTime(2025, 2, 25, 22, 27, 9, 0, DateTimeKind.Unspecified), null, 5, "добре изглежда роботчето : )", 2 },
                    { 4, new DateTime(2025, 2, 25, 22, 53, 26, 0, DateTimeKind.Unspecified), null, 5, ": D", 1 },
                    { 6, new DateTime(2025, 3, 1, 18, 15, 20, 0, DateTimeKind.Unspecified), null, 3, "ако имате въпроси питайте и ще пробвам да отговоря бързо : )", 1 },
                    { 2004, new DateTime(2025, 3, 18, 12, 2, 17, 0, DateTimeKind.Unspecified), null, 1002, "<p><a href=\"https://www.printables.com/model/331064-dnd-coins\" target=\"_blank\">монетите, които беше намерил</a> са доста готини :D</p>", 1 }
                });

            migrationBuilder.InsertData(
                table: "LikedProjects",
                columns: new[] { "ProjectId", "UserId", "Id" },
                values: new object[,]
                {
                    { 3, 1, 0 },
                    { 5, 1, 0 },
                    { 1002, 1, 0 },
                    { 2002, 1, 0 },
                    { 2003, 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "LikedComments",
                columns: new[] { "CommentId", "UserId", "Id" },
                values: new object[,]
                {
                    { 3, 1, 0 },
                    { 4, 1, 0 },
                    { 6, 1, 0 },
                    { 2004, 1, 0 },
                    { 3, 2, 0 },
                    { 4, 2, 0 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Projects_ProjectId",
                table: "Comments",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikedComments_AspNetUsers_UserId",
                table: "LikedComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LikedComments_Comments_CommentId",
                table: "LikedComments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Images_ImageId",
                table: "Projects",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Projects_ProjectId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_LikedComments_AspNetUsers_UserId",
                table: "LikedComments");

            migrationBuilder.DropForeignKey(
                name: "FK_LikedComments_Comments_CommentId",
                table: "LikedComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Images_ImageId",
                table: "Projects");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2002);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2003);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3002);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3003);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3004);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3005);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3006);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1013);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1015);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1016);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1017);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2010);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2011);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3011);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3012);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3017);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3018);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3019);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3020);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3021);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3022);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3023);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3024);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3025);

            migrationBuilder.DeleteData(
                table: "LikedComments",
                keyColumns: new[] { "CommentId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "LikedComments",
                keyColumns: new[] { "CommentId", "UserId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "LikedComments",
                keyColumns: new[] { "CommentId", "UserId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "LikedComments",
                keyColumns: new[] { "CommentId", "UserId" },
                keyValues: new object[] { 2004, 1 });

            migrationBuilder.DeleteData(
                table: "LikedComments",
                keyColumns: new[] { "CommentId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "LikedComments",
                keyColumns: new[] { "CommentId", "UserId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "LikedProjects",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "LikedProjects",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "LikedProjects",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 1002, 1 });

            migrationBuilder.DeleteData(
                table: "LikedProjects",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 2002, 1 });

            migrationBuilder.DeleteData(
                table: "LikedProjects",
                keyColumns: new[] { "ProjectId", "UserId" },
                keyValues: new object[] { 2003, 1 });

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2004);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2013);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3010);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3013);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3014);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3015);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3016);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2002);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2003);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3026);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3027);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1014);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2012);

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "Projects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1,
                column: "Path",
                value: "path1");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2,
                column: "Path",
                value: "path2");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "Path",
                value: "path3");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "Path",
                value: "path4");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5,
                column: "Path",
                value: "path5");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "Path",
                value: "path6");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Projects_ProjectId",
                table: "Comments",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LikedComments_AspNetUsers_UserId",
                table: "LikedComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LikedComments_Comments_CommentId",
                table: "LikedComments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Images_ImageId",
                table: "Projects",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }
    }
}
