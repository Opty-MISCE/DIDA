# Run
../BasicVersion/GSTORE/PCS/bin/Debug/netcoreapp3.1/PCS.exe < PCS/BasicVersion/Args.txt & PCSPID=$!
../BasicVersion/GSTORE/PuppetMaster/bin/Debug/netcoreapp3.1/PuppetMaster.exe

# Cleanup
kill -9 $PCSPID
