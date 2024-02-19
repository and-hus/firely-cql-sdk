﻿using Hl7.Fhir.Model;

namespace Hl7.Cql.Packaging.ResourceWriters
{
    /// <summary>
    /// Represents a generic writer of resources.
    /// </summary>
    public abstract class ResourceWriter
    {
        /// <summary>
        /// Loops over the given resources, and writes time with the <see cref="WriteResource"/> method.
        /// </summary>
        /// <param name="resources">the resources to write</param>
        public abstract void WriteResources(IEnumerable<Resource> resources);

        /// <summary>
        /// Writes the given resource.
        /// </summary>
        /// <param name="resource">the resource to write</param>
        public abstract void WriteResource(Resource resource);

        /// <summary>
        /// Ensures that the specified directory exists, and if it doesn't it creates it
        /// </summary>
        /// <param name="directory">the directory</param>
        /// <param name="timeoutMs">optional override for how long to wait</param>
        /// <exception cref="InvalidOperationException"></exception>
        private protected static void EnsureDirectory(DirectoryInfo directory, int timeoutMs = 5000)
        {
            var now = DateTime.Now;
            var loop = true;
            var timeout = TimeSpan.FromMilliseconds(timeoutMs);
            while (!directory.Exists && loop)
            {
                directory.Create();
                directory.Refresh();
                if (DateTime.Now.Subtract(now) > timeout)
                    throw new InvalidOperationException($"Unable to create directory {directory.FullName} after {timeout}");
            }
        }
    }
}
