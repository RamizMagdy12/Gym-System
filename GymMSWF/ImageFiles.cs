namespace GymMSWF
{
    internal static class ImageFiles
    {
        public static Image? TryLoad(string? storedPath)
        {
            string? path = Resolve(storedPath);
            if (path == null)
                return null;

            using var source = Image.FromFile(path);
            return new Bitmap(source);
        }

        public static Image Placeholder(string? caption, Size size)
        {
            int width = Math.Max(size.Width, 48);
            int height = Math.Max(size.Height, 48);
            var image = new Bitmap(width, height);
            using var graphics = Graphics.FromImage(image);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.Clear(Color.FromArgb(47, 61, 71));

            string letter = string.IsNullOrWhiteSpace(caption) ? "?" : caption.Trim()[0].ToString().ToUpperInvariant();
            using var font = new Font("Segoe UI", Math.Max(18, height / 4f), FontStyle.Bold);
            using var format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            graphics.DrawString(letter, font, Brushes.White, new RectangleF(0, 0, width, height), format);
            return image;
        }

        public static string Store(string sourcePath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath) || !File.Exists(sourcePath))
                return sourcePath;

            string imagesDir = Path.Combine(AppContext.BaseDirectory, "Images");
            Directory.CreateDirectory(imagesDir);

            string fileName = $"{Guid.NewGuid():N}{Path.GetExtension(sourcePath)}";
            string destination = Path.Combine(imagesDir, fileName);
            File.Copy(sourcePath, destination, true);
            return destination;
        }

        public static string? Resolve(string? storedPath)
        {
            if (string.IsNullOrWhiteSpace(storedPath))
                return null;

            if (File.Exists(storedPath))
                return storedPath;

            string fileName = Path.GetFileName(storedPath);
            foreach (string directory in CandidateDirectories())
            {
                string candidate = Path.Combine(directory, fileName);
                if (File.Exists(candidate))
                    return candidate;
            }

            return null;
        }

        private static IEnumerable<string> CandidateDirectories()
        {
            yield return AppContext.BaseDirectory;
            yield return Path.Combine(AppContext.BaseDirectory, "Images");
            yield return Path.Combine(AppContext.BaseDirectory, "Resources");

            var directory = new DirectoryInfo(AppContext.BaseDirectory);
            for (int i = 0; i < 6 && directory != null; i++, directory = directory.Parent)
            {
                yield return Path.Combine(directory.FullName, "Images");
                yield return Path.Combine(directory.FullName, "Resources");
                yield return directory.FullName;
            }
        }
    }
}
