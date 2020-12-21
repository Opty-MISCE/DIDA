if [ "$#" -ne 1 ]; then
  echo "Usage: Takes Client Id As Argument" >&2
  exit 1
fi

# Run
../AdvancedVersion/GSTORE/Server/bin/Debug/netcoreapp3.1/Server.exe < Servers/1/Args.txt & S1PID=$!
../AdvancedVersion/GSTORE/Server/bin/Debug/netcoreapp3.1/Server.exe < Servers/2/Args.txt & S2PID=$!
../AdvancedVersion/GSTORE/Server/bin/Debug/netcoreapp3.1/Server.exe < Servers/3/Args.txt & S3PID=$!
../AdvancedVersion/GSTORE/Client/bin/Debug/netcoreapp3.1/Client.exe < Clients/$1/Args.txt

# Cleanup
kill -9 $S1PID
kill -9 $S2PID
kill -9 $S3PID
